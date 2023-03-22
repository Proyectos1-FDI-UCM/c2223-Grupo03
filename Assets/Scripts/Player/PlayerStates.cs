using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class PlayerStates : MonoBehaviour
{
    private Vector3 _alturaFinal;
    private Vector3 _alturaInicial;
    private float _speed = 1.0f;
    private float _time;

    #region parameters
    [SerializeField] private GameObject _boxPrefab;
    private GameObject _boxInstance;
    [SerializeField] private float _timeOutPill = 10;
    private float _oldSpeed;
    private Vector3 _boxTransform;
    #endregion


    #region properties

    private bool _withEffect = false;
    public bool WithEffect { get { return _withEffect; } }

    private bool _hidden;
    public bool Hidden { get { return _hidden; } }

    private bool _isBox;
    public bool IsBox { get { return _isBox; } }
    #endregion

    #region references
    [SerializeField] private GameObject _warning;
    [SerializeField] private GameObject _heart;
    [SerializeField] private GameObject _safeZone;
    [SerializeField] private GameObject _heartBar;

    [SerializeField] private GameObject _clockPrefab;
    private GameObject _clock;

    [SerializeField] private GameObject _playerInCloset;
    private Inventory _inventory;
    private GameObject _player;
    private Animator _playerAnimator;
    private AudioSource _audioSource;
    private BoxAnimation _boxAnimation;
    private Animator _boxAnimator;
    #endregion


    #region methods
    public void Clock()
    {
        _inventory.EliminaObjeto(3);
        _clock = Instantiate(_clockPrefab, _player.transform.position, new Quaternion(0, 0, 0, 0));
        _clock.GetComponent<ClockDistractionComponent>().SetInstance = true;
    }
    public void EnterCloset()
    {
        _playerInCloset.SetActive(true);
    }
    public void ExitCloset()
    {
        _playerInCloset.SetActive(false);
    }
    public void EnterBox() // player entra a caja
    {
        _audioSource.Play();
        new WaitForSeconds(2);
        _boxInstance = Instantiate(_boxPrefab, _boxTransform, Quaternion.identity);
        _boxAnimator.SetTrigger("CajaFall");
        _player.SetActive(false);
        _playerInCloset.SetActive(true);
        
        _isBox = true;
    }
    public void ExitBox() // player sale de caja
    {
        Destroy(_boxInstance);
        _player.SetActive(true);
        _audioSource.Play();
        _playerInCloset.SetActive(false);
        _inventory._cajaEquipado = false;
        _inventory.EliminaObjeto(2);
        _isBox = false;
    }
    public void PillEffect()
    {
        if (!_withEffect)
        {
            //activamos efecto pasti 
            _heart.GetComponent<HeartMove>().enabled = false;
            _safeZone.GetComponent<ProximityComponent>().enabled = false;
            _heartBar.SetActive(false);
            Invoke("Flicker", _timeOutPill - 4);
            Invoke("ActiveHeart", _timeOutPill);
            _withEffect = true;
            //quitamos pasti del inventario
            _inventory._pildoraEquipado = false;
            _inventory.EliminaObjeto(1);
        }
    }

    public void Pause()
    {
        if (!GameManager.Instance.IsPause)
        {
            _heart.GetComponent<HeartMove>().enabled = false;
            _safeZone.GetComponent<ProximityComponent>().enabled = false;
            _heart.GetComponent<HeartDetection>().enabled = false;
        }
        else
        {
            _heart.GetComponent<HeartMove>().enabled = true;
            _safeZone.GetComponent<ProximityComponent>().enabled = true;
            _heart.GetComponent<HeartDetection>().enabled = true;
        }

    }

    private void Flicker()
    {
        _heartBar.SetActive(true);
        _heartBar.transform.GetChild(0).GetComponent<ParpadeoComponent>().enabled = true;
        _heartBar.transform.GetChild(1).GetComponent<ParpadeoComponent>().enabled = true;
        _heartBar.transform.GetChild(2).GetComponent<ParpadeoComponent>().enabled = true;

    }

    private void ActiveHeart()
    {
        _heartBar.transform.GetChild(0).GetComponent<ParpadeoComponent>().enabled = false;
        _heartBar.transform.GetChild(0).GetComponent<Image>().color += new Color(0, 0, 0, 0.25f);
        _heartBar.transform.GetChild(1).GetComponent<ParpadeoComponent>().enabled = false;
        _heartBar.transform.GetChild(1).GetComponent<Image>().color += new Color(0, 0, 0, 0.25f);
        _heartBar.transform.GetChild(2).GetComponent<ParpadeoComponent>().enabled = false;
        _heartBar.transform.GetChild(2).GetComponent<Image>().color += new Color(0, 0, 0, 0.25f);
        _heart.GetComponent<HeartMove>().enabled = true;
        _safeZone.GetComponent<ProximityComponent>().enabled = true;
        _withEffect = false;
    }

    public void CancelMovementTutorial()
    {
        _playerAnimator.SetBool("Sweat", true);
        _oldSpeed = GetComponent<MovementComponent>().speed;
        GetComponent<MovementComponent>().speed = 0;
    }
    public void ActiveMovementTutorial()
    {
        GetComponent<MovementComponent>().speed = _oldSpeed;
        _playerAnimator.SetBool("Sweat", false);
    }
    public void SweatCancelMovement() // fatiga al fallar 3 veces
    {
        _playerAnimator.SetBool("Sweat", true);
        _oldSpeed = GetComponent<MovementComponent>().speed;
        GetComponent<MovementComponent>().speed = 0;
        Invoke("SweatActiveMovement", 3);
    }

    private void SweatActiveMovement() // reanuda el movimiento
    {
        _playerAnimator.SetBool("Sweat", false);
        GetComponent<MovementComponent>().speed = _oldSpeed;
    }
    #endregion

    void Start()
    {
        _isBox = false;
        _inventory = GameManager.Instance.GetComponent<Inventory>();
        _player = GameManager.Player;
        _playerAnimator = _player.GetComponent<Animator>();
        _audioSource = _player.GetComponent<AudioSource>();
        _boxAnimation = _boxPrefab.GetComponent<BoxAnimation>();
        _boxAnimator = _boxPrefab.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _boxTransform = _player.transform.position + new Vector3(0, 2, 0);
        _time = _speed * Time.deltaTime;
        _alturaInicial = _boxTransform;
        _alturaFinal = _boxTransform + new Vector3(0, -2, 0);
        _boxPrefab.transform.position = Vector3.MoveTowards(_alturaInicial, _alturaFinal, _time);
    }

    public void AnimacionCaja()
    {
       
    }
}
