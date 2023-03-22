using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public enum Menus { PAUSE, OPTIONS, CONTROLS, SOUND, NoMenu };

    #region parameters
    [SerializeField] private float _audioSFX;
    [SerializeField] private float _audioMusic;

    #endregion

    #region references

    [SerializeField] GameObject _UIManager;
    [SerializeField] GameObject _enemyGroup;

    #endregion

    #region properties

    private bool _isInPause;

    private int _amountOfChildren;

    private Menus _actualMenu;
    private Menus _beforeMenu;

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

    static private GameObject _camera;
    static public GameObject Camera { get { return _camera;} }
    
    //Volumen del audio 
    public float getSFX { get { return _audioSFX; } }
    public float getMusic { get { return _audioMusic; } }
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
            _actualMenu = Menus.PAUSE;
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
            _actualMenu = Menus.NoMenu;
        }
    }

    private void UpdateMenu(Menus newMenu)
    {
        if (newMenu == Menus.OPTIONS)
        {
            Debug.Log("Llego 3");
            _UIManager.GetComponent<UIManager>().ChangeMenu(Menus.OPTIONS);
        }
        else if (newMenu == Menus.CONTROLS)
        {
            _UIManager.GetComponent<UIManager>().ChangeMenu(Menus.CONTROLS);
        }
        else if (newMenu == Menus.SOUND)
        {
            _UIManager.GetComponent<UIManager>().ChangeMenu(Menus.SOUND);
        }
    }

    public void RequestMenuChange(Menus newMenu)
    {
        if (_actualMenu == Menus.PAUSE && (newMenu == Menus.OPTIONS))
        {
            Debug.Log("LLego 2");
            _beforeMenu = _actualMenu;
            _actualMenu = newMenu;
            UpdateMenu(newMenu);
        }
        else if (_actualMenu == Menus.OPTIONS && (newMenu == Menus.CONTROLS || newMenu == Menus.SOUND))
        {
            _beforeMenu = _actualMenu;
            _actualMenu = newMenu;
            UpdateMenu(newMenu);
        }
    }

    public void changeSound(string soundType, float newValue)
    {
        Debug.Log("numbah");
        if (soundType == "MusicSlider")
        {
            _audioMusic = newValue;
        } else if (soundType == "SFXSlider") 
        {
            Debug.Log("ONE");
            _audioSFX = newValue;
        }
    }
    #endregion
  
    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            _player = GameObject.Find("Player");
            _playerStates = _player.GetComponent<PlayerStates>();
            _inputComponent = GetComponent<InputComponent>();
            _camera = Camera.Main;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        _isInPause= false;
        _amountOfChildren = _enemyGroup.transform.childCount;
        _audioMusic = _audioSFX = 1;
    }
    void Update()
    {

    }
}
