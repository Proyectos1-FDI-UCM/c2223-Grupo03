using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEvents : MonoBehaviour
{
    public int numOfEvent;
    [SerializeField] private GameObject _corazonRoto;
    [SerializeField] private GameObject _pulsaEspacioTexto;
    [SerializeField] private GameObject _textoPildora;
    [SerializeField] private GameObject _enemigo1;
    [SerializeField] private GameObject _enemigo2;
    [SerializeField] private GameObject _muroInvisible;
    [SerializeField] private Transform _changeCameraPosition;
    [SerializeField] private GameObject _textoProximidadLatidos;
    private GameObject _instancePulsaEspacioTexto;
    private GameObject _instanceTextoPildora;
    private GameObject _instanceTextoProximidadLatidos;
    private GameObject _instanceEnemigo1;
    private GameObject _instanceEnemigo2;
    private GameObject _instanceMuroInvisible;

    private PlayerStates _playerStates;
    private HeartDetection _heartDetection;
    private HeartMove _heartMove;
    private Animator _animatorHeartBar;
    private GameObject _blackRooms;

    private GameObject _playerInCloset;
    private bool intoCloset;

    [SerializeField] GameObject _firstCloset;
    public void Triggered()
    {
        numOfEvent++;
        ChangeEvent();
    }
    private void ChangeEvent()
    {
        switch (numOfEvent)
        {
            case 1:
                HeartBeatEventStart();
                break;
            case 2:
                SpawnTextHeartBar();
                break;
            case 3:
                DespawnTextHeartBar();
                break;
            case 4:
                SpawnTextPill();
                break;
            case 5:
                ShowEnemy();
                break;
            case 6:
                InsideCloset();
                break;
        }
    }
    private void InsideCloset()
    {
        intoCloset = true;
        _instanceEnemigo2 = Instantiate(_enemigo2);
        Destroy(_instanceMuroInvisible);
        _instanceTextoProximidadLatidos = Instantiate(_textoProximidadLatidos, transform.GetChild(6).transform);
        Invoke("FinishCloset", 7);
    }
    private void FinishCloset()
    {
        intoCloset = false;
        GameManager.Player.SetActive(true);
        _playerInCloset.SetActive(false);
        Destroy(_instanceEnemigo2);
        Destroy(_instanceTextoProximidadLatidos);
        GameManager.Instance.GetComponent<PauseInput>().enabled = true;
        Camera.main.GetComponent<CameraFollow>().RestartPlayerFocus();
    }
    private void ShowEnemy()
    {
        _blackRooms.SetActive(false);
        _instanceEnemigo1 = Instantiate(_enemigo1);
        Camera.main.GetComponent<CameraFollow>()._smoothSpeed = 0.02f;
        Camera.main.GetComponent<CameraFollow>().ChangeCameraPosition(_changeCameraPosition);
        Invoke("StopShowEnemy", 2f);
    }
    private void StopShowEnemy()
    {
        Camera.main.GetComponent<CameraFollow>().ChangeCameraPosition(GameManager.Player.transform);
        Invoke("StopShowEnemy2", 0.7f);
        _instanceMuroInvisible = Instantiate(_muroInvisible);
        _blackRooms.SetActive(true);
    }
    private void StopShowEnemy2()
    {
        _firstCloset.GetComponent<ClosetComponent>().enabled = true;
        Destroy(_instanceEnemigo1);
        Camera.main.GetComponent<CameraFollow>()._smoothSpeed = 2f;
    }
    private void SpawnTextPill()
    {
        _instanceTextoPildora = Instantiate(_textoPildora,transform.GetChild(6).transform);
        Invoke("DespawnTextPill", 4.5f);
    }
    private void DespawnTextPill()
    {
        Destroy(_instanceTextoPildora);
    }
    private void SpawnTextHeartBar()
    {
        _heartDetection.CanPress();
        _instancePulsaEspacioTexto = Instantiate(_pulsaEspacioTexto, transform.GetChild(6).transform);
    }
    private void DespawnTextHeartBar()
    {
        Destroy(_instancePulsaEspacioTexto);
        _playerStates.ActiveMovementTutorial();
    }
    private void HeartBeatEventStart()
    {
        _playerStates.CancelMovementTutorial();
        Instantiate(_corazonRoto, transform.GetChild(6).transform);
        Invoke("HeartBeatEventStop", 5);
    }
    private void HeartBeatEventStop()
    {
        _heartMove.ActiveMovement();
        _animatorHeartBar.SetTrigger("Salir");
    }
    private void Update()
    {
        if (numOfEvent == 5 && !GameManager.Player.active)
        {
            numOfEvent++;
            ChangeEvent();
        }
        if (intoCloset)
        {
            GameManager.Player.SetActive(false);
            _playerInCloset.SetActive(true);
            Camera.main.GetComponent<CameraFollow>().ChangeCameraPosition(_firstCloset.transform);
        }
    }
    void Start()
    {
        numOfEvent = 0;
        intoCloset = false;
        _playerStates = GameManager.Player.GetComponent<PlayerStates>();
        _heartDetection = GameObject.Find("Heart").GetComponent<HeartDetection>();
        _heartMove = GameObject.Find("Heart").GetComponent<HeartMove>();
        _heartMove.CancelMovementTutorial();
        _animatorHeartBar = GameObject.Find("HeartBeat").GetComponent<Animator>();
        _blackRooms = GameObject.Find("BlackRooms");
        _playerInCloset = GameObject.Find("PlayerInCloset");
        _playerInCloset.SetActive(false);
        _heartDetection.CantPress();
        GameManager.Instance.GetComponent<PauseInput>().enabled = false;
        _firstCloset.GetComponent<ClosetComponent>().enabled = false;
    }
}
