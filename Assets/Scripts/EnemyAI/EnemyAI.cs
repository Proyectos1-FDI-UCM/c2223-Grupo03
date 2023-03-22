using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    #region References

    [Header("Parámetros enemigo")]
    private Rigidbody2D _player;
    [SerializeField] private float _speed;
    [SerializeField] private bool _chasing;
    [SerializeField] float _timeToStopChasing;
    float _timeChasing;
    bool _isMoving;
    private float _oldSpeed;
    public bool Moving { set { _isMoving = value; } }
    public bool Chasing { get { return _chasing; } }
    public enum EnemyType { Brown, Blue, Red, Green};

    [Header("Parámetros cono visión")]
    [SerializeField] private GameObject _cone;
    private VisionCone _fovEnemigo;
    [SerializeField] float _coneFov;
    [SerializeField] float _coneDistance;
    private GameObject _closet;
    public GameObject SetCloset { set { _closet = value; } }
    public GameObject GetCloset { get { return _closet; } }

    [Header("Parámetros pathing")]
    [SerializeField] private GameObject _path;
    [SerializeField] private bool _cicle;

    private AudioSource _myAudio;
    private float _audioVolume;

    private GameObject _myHeadSign;
    private SpriteRenderer _myExclamationRender;
    [SerializeField] Color _exclaimColor;
    private AudioSource _myChasePlayer;

    private GameObject _sceneCamera;
    #endregion

    #region Variables
    [SerializeField] private Transform[] _points;
    private NavMeshAgent _navMeshAgent;
    private Rigidbody2D _enemyRigidbody;
    
    private bool forward; //bool para en caso de no ser ciclico poder dar la vuelta
    private int i; //index
    private Vector2 direction; //direccion del cono de vision

    private Animator _animator;

    [SerializeField] private float _time;
    [SerializeField]
    private float _timeChase;
    private float _timeToSound;

    private bool _paused;
    #endregion

    #region methods

    private void Pause()
    {

        if (!GameManager.Instance.IsPause)
        {
            _navMeshAgent.speed = 0;
            _paused = true;
        }
        else
        {
            _navMeshAgent.speed = _speed;
            UpdateSound();
            _paused = false;
        }
    }

    private void UpdateSound()
    {
        _myAudio.volume = _audioVolume * GameManager.Instance.getSFX;
    }

    //actualiza los valores de movimiento en el animator
    private void UpdateAnimatorValues()
    {
        _animator.SetFloat("Horizontal", direction.x);
        _animator.SetFloat("Vertical", direction.y);
    }
    // funciones que comprueban si el enemigo tiene que dejar de perseguir
    public void StartChase()
    {
        _myExclamationRender.color = new Color(255, 255, 0, 255);
        _timeChasing = 0;
        _chasing = true;
        _myAudio.pitch = 3;
        _myChasePlayer.mute = false;
        _sceneCamera.GetComponent<AudioSource>().mute = true;
    }
    private void UpdateChase()
    {
        if (_timeChasing < _timeToStopChasing)
        {
            _timeChasing = _timeChasing + Time.deltaTime;
            _sceneCamera.GetComponent<AudioSource>().mute = true;
        }
        else
        {
            _chasing = false;
            _myAudio.pitch = 2;
            _myChasePlayer.mute = true;
            _sceneCamera.GetComponent<AudioSource>().mute = false;
            _myExclamationRender.color = _exclaimColor + new Color (0, 0, 0, -1);
        }
    }
    // Funcion auxiliar, guarda en una array puntos de un camino 
    // para no tener que estar asignandolos manualmente
    private void SetPointsFromPath() 
    {
        int pointNum = _path.transform.childCount;
        _points = new Transform[pointNum];
        int i = 0;
        foreach (Transform child in _path.transform)
        {
            _points[i] = child;
            i++;
        }
    }
    private void Movement()
    {
        if (_chasing) //Follow player
        {
            _navMeshAgent.SetDestination(_player.position);
            direction = (_player.position - _enemyRigidbody.position).normalized;
        }
        else // Follow points
        {
            if (_cicle) // en ciclo
            {
                if (i < _points.Length)
                {
                    if (Vector2.Distance(_enemyRigidbody.position, _points[i].position) > 0.1f)
                    {
                        _navMeshAgent.SetDestination(_points[i].position);
                        direction = ((Vector2)_points[i].position - _enemyRigidbody.position).normalized;
                    }
                    else
                        i = (i + 1) % _points.Length;
                }
            }
            else // volviendo por sus pasos
            {
                if (i < _points.Length && forward)
                {
                    if (Vector2.Distance(_enemyRigidbody.position, _points[i].position) > 0.1f)
                    {
                        _navMeshAgent.SetDestination(_points[i].position);
                        direction = ((Vector2)_points[i].position - _enemyRigidbody.position).normalized;
                    }
                    else
                        i++;
                }
                else if (i > 0 && !forward)
                {
                    if (Vector2.Distance(_enemyRigidbody.position, _points[i].position) > 0.1f)
                    {
                        _navMeshAgent.SetDestination(_points[i].position);
                        direction = ((Vector2)_points[i].position - _enemyRigidbody.position).normalized;
                    }
                    else
                        i--;
                }
                else
                {
                    forward = !forward;
                    if (!forward)
                        i--;
                }
            }
        }
    }

    /// <summary>
    /// Invierte la dirección (para los azules)
    /// </summary>
    public void InvertDirection()
    {
        direction = -direction;
    }

    /// <summary>
    /// Cambia la dirección para mirar a un objeto
    /// </summary>
    /// <param name="objectSeen"> GameObject al que quieres mirar </param>
    public void LookAtObject(GameObject objectSeen)
    {
        direction = ((Vector2)objectSeen.transform.position - _enemyRigidbody.position).normalized;
    }

    /// <summary>
    /// Para enemigos rojos y azules (aunque también sirve para marrones diesese el caso). Establece donde se tiene que parar el enemigo
    /// </summary>
    /// <param name="myType"> Tipo de enemigo </param>
    public void StopDestination (EnemyType myType)
    {
        if (myType == EnemyType.Blue || myType == EnemyType.Brown)
        {
            _navMeshAgent.SetDestination(_enemyRigidbody.position);
        } else if (myType == EnemyType.Red)
        {
            _navMeshAgent.SetDestination(_enemyRigidbody.position + 3 * direction);
        }
    }

    /// <summary>
    /// Permite que el enemigo se mueva a una dirección prefijada
    /// </summary>
    /// <param name="destination"> Posición a la que queremos que llegue el enemigo </param>
    public void SetDestination(Vector3 destination)
    {
        _navMeshAgent.SetDestination(destination);
    }


    public void Exclaim()
    {
        _myExclamationRender.color = new Color(255, 255, 0, 255);
    }
    #endregion

    void Start()
    {
        i = 0;
        forward = true;

        _fovEnemigo = _cone.GetComponent<VisionCone>();
        _fovEnemigo.SetFov(_coneFov);
        _fovEnemigo.SetDistance(_coneDistance);

        SetPointsFromPath();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _enemyRigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;

        _isMoving = true;

        _player = GameManager.Player.GetComponent<Rigidbody2D>();
        _navMeshAgent.speed = _speed;

        _myAudio = GetComponent<AudioSource>();
        _myAudio.pitch = 2;
        _audioVolume = _myAudio.volume;

        _myHeadSign = transform.GetChild(1).gameObject;
        _myExclamationRender = _myHeadSign.GetComponent<SpriteRenderer>();
        _myExclamationRender.color = _exclaimColor;
        _myChasePlayer = _myHeadSign.GetComponent<AudioSource>();

        _sceneCamera = GameManager.getCamera.gameObject;
    }
    private void Update()
    {
        if (!_paused)
        {
            _fovEnemigo.SetAim(direction);
            _fovEnemigo.SetOrigin(_enemyRigidbody.position);
            UpdateChase();
            UpdateAnimatorValues();
            if (_timeToSound < 0)
            {
                if (_chasing)
                {
                    _timeToSound = Random.Range(_timeChase, _timeChase + 0.1f);
                    _myAudio.Play();
                }
                else
                {
                    _timeToSound = Random.Range(_time, _time + 0.2f);
                    _myAudio.Play();
                }
            }
            else
            {
                _timeToSound -= Time.deltaTime;
            }
        }       
    }
    void FixedUpdate()
    {
        if(_isMoving)
        {
            Movement();
        }
    }
}
