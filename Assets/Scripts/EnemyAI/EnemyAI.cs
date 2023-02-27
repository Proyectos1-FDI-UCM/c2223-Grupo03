using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    #region References

    [Header("Parámetros enemigo")]
    [SerializeField] private Rigidbody2D _player;
    [SerializeField] private float _speed;
    [SerializeField] private bool _chasing;
    [SerializeField] float _timeToStopChasing;
    float _timeChasing;
    bool _isMoving;
    public bool Moving { set { _isMoving = value; } }
    public bool Chasing { get { return _chasing; } }

    [Header("Parámetros cono visión")]
    [SerializeField] private GameObject _cone;
    private VisionCone _fovEnemigo;
    [SerializeField] float _coneFov;
    [SerializeField] float _coneDistance;

    [Header("Parámetros pathing")]
    [SerializeField] private GameObject _path;
    [SerializeField] private bool _cicle;

    private VisionCone _visionCone;
    private Animator _animator;
    #endregion

    #region Variables
    [SerializeField] private Transform[] _points;
    private NavMeshAgent _navMeshAgent;
    private Rigidbody2D _enemyRigidbody;
    
    private bool forward; //bool para en caso de no ser ciclico poder dar la vuelta
    private int i; //index
    private Vector2 direction; //direccion del cono de vision
    #endregion

    #region 
    //actualiza los valores de movimiento en el animator
    private void UpdateAnimatorValues()
    {
        _animator.SetFloat("Horizontal", direction.x);
        _animator.SetFloat("Vertical", direction.y);
    }
    // funciones que comprueban si el enemigo tiene que dejar de perseguir
    public void StartChase()
    {
        _timeChasing = 0;
        _chasing = true;
    }
    private void UpdateChase()
    {
        if (_timeChasing < _timeToStopChasing)
        {
            _timeChasing = _timeChasing + Time.deltaTime;
        }
        else
        {
            _chasing = false;
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

    public void InvertDirection()
    {
        direction = -direction;
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

    }
    private void Update()
    {
        _fovEnemigo.SetAim(direction);
        _fovEnemigo.SetOrigin(_enemyRigidbody.position);
        UpdateChase();
        UpdateAnimatorValues();
    }
    void FixedUpdate()
    {
        if(_isMoving)
        {
            Movement();
        }
    }
}
