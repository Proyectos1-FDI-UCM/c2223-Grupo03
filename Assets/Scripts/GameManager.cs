using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region parameters
    private float _audioSFX;
    private float _audioMusic;

    #endregion

    #region references

    [SerializeField] GameObject _UIManager;
    [SerializeField] GameObject _enemyGroup;

    #endregion

    #region properties

    private bool _isInPause;

    private int _amountOfChildren;

    public bool IsPause
    {
        get
        {
            return _isInPause;
        }
    }

    #endregion

    #region getter/setters
    // Instance para poder coger variables del gamemanager
    static private GameManager _instance;
    static public GameManager Instance { get { return _instance; } }

    //referencia al player
    static private GameObject _player;
    static public GameObject Player { get { return _player; } }

    static private PlayerStates _playerStates;
    static public PlayerStates PlayerStates { get { return _playerStates; } }

    static private InputComponent _inputComponent;
    static public InputComponent InputComponent { get { return _inputComponent; } }
    
    //Volumen del audio 
    public float getSFX { get { return _audioSFX; } }
    public float setSFX { set { _audioSFX = value; } }
    public float getMusic { get { return _audioMusic; } }
    public float setMusic { set { _audioMusic = value; } }
    #endregion

    #region methods

    public void ChangePause()
    {
        _player.GetComponent<PlayerStates>().Pause();
        _player.GetComponent<MovementComponent>().Pause();

        _UIManager.GetComponent<UIManager>().PauseMenu();

        _enemyGroup.BroadcastMessage("Pause");

        if (!_isInPause)
        {
            _player.GetComponent<Animator>().enabled = false;
            GetComponent<InputComponent>().enabled = false;

            for (int i = 0; i < _enemyGroup.transform.childCount; i++)
            {
                _enemyGroup.transform.GetChild(i).transform.GetChild(0).GetComponent<Animator>().enabled = false;
            }
            
            _isInPause= true;
        }
        else
        {
            _player.GetComponent<Animator>().enabled = true;
            GetComponent<InputComponent>().enabled = true;

            for (int i = 0; i < _enemyGroup.transform.childCount; i++)
            {
                _enemyGroup.transform.GetChild(i).transform.GetChild(0).GetComponent<Animator>().enabled = true;
            }

            _isInPause = false;
        }
    }
    

    #endregion
    void Awake()
    {
        _instance = this;
        _player = GameObject.Find("Player");
        _playerStates = _player.GetComponent<PlayerStates>();
        _inputComponent = GetComponent<InputComponent>();
    }
    void Start()
    {
        _isInPause= false;
        _amountOfChildren = _enemyGroup.transform.childCount;
    }
    void Update()
    {

    }
}
