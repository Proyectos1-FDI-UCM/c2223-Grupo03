using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public enum Menus { PAUSE, OPTIONS, CONTROLS, SOUND, NoMenu, TECLADO};

    #region parameters
    [SerializeField] private float _audioSFX;
    [SerializeField] private float _audioMusic;

    [SerializeField] private float _audioVolume;
    #endregion

    #region references

    [SerializeField] GameObject _UIManager;
    [SerializeField] GameObject _enemyGroup;

    [SerializeField] GameObject _deathAnimation1;
    [SerializeField] GameObject _deathAnimation2;
    #endregion

    #region properties

    private bool _isInPause;

    private int _amountOfChildren;

    private Menus _actualMenu;
    public Menus ActualMenu
    {
        get { return _actualMenu; }
    }

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

    static private Camera _camera;
    static public Camera getCamera { get { return _camera;} }
    
    //Volumen del audio 
    public float getSFX { get { return _audioSFX; } }
    public float getMusic { get { return _audioMusic; } }
    #endregion

    #region 

    public void GameOver()
    {
        GameObject canvas = GameObject.Find("Canvas");
        Destroy(_player);
        Instantiate(_deathAnimation1, canvas.transform);
        Instantiate(_deathAnimation2, canvas.transform);
        Invoke("ChangeSceneDeath", 1.5f);
    }
    private void ChangeSceneDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
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

            GetComponent<MenuComponent>().ChangeMenu(Menus.PAUSE);
            
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
            _UIManager.GetComponent<UIManager>().ChangeMenu(Menus.OPTIONS);
            GetComponent<MenuComponent>().ChangeMenu(Menus.OPTIONS);
        }
        else if (newMenu == Menus.CONTROLS)
        {
            _UIManager.GetComponent<UIManager>().ChangeMenu(Menus.CONTROLS);
            GetComponent<MenuComponent>().ChangeMenu(Menus.CONTROLS);
        }
        else if (newMenu == Menus.SOUND)
        {
            _UIManager.GetComponent<UIManager>().ChangeMenu(Menus.SOUND);
            GetComponent<MenuComponent>().ChangeMenu(Menus.SOUND);
        }
        else if (newMenu == Menus.PAUSE)
        {
            _UIManager.GetComponent<UIManager>().ChangeMenu(Menus.PAUSE);
            GetComponent<MenuComponent>().ChangeMenu(Menus.PAUSE);
        }
        else if (newMenu == Menus.TECLADO)
        {
            _UIManager.GetComponent<UIManager>().ChangeMenu(Menus.TECLADO);
            GetComponent<MenuComponent>().ChangeMenu(Menus.TECLADO);
        }
    }

    public void RequestMenuChange(Menus newMenu)
    {
        if ((_actualMenu == Menus.PAUSE || _actualMenu == Menus.CONTROLS || _actualMenu == Menus.SOUND || _actualMenu == Menus.TECLADO) && (newMenu == Menus.OPTIONS))
        {
            _actualMenu = newMenu;
            UpdateMenu(newMenu);
        }
        else if (_actualMenu == Menus.OPTIONS && (newMenu == Menus.CONTROLS || newMenu == Menus.SOUND))
        {
            _actualMenu = newMenu;
            UpdateMenu(newMenu);
        }
        else if (_actualMenu == Menus.OPTIONS && (newMenu == Menus.PAUSE))
        {
            _actualMenu = newMenu;
            UpdateMenu(newMenu);
        }
        else if (_actualMenu == Menus.CONTROLS && (newMenu == Menus.TECLADO))
        {
            _actualMenu = newMenu;
            UpdateMenu(newMenu);
        }
        else if (_actualMenu == Menus.TECLADO && (newMenu == Menus.CONTROLS))
        {
            _actualMenu = newMenu;
            UpdateMenu(newMenu);
        }
    }

    public void changeSound(string soundType, float newValue)
    {
        if (soundType == "MusicSlider")
        {
            _audioMusic = newValue;
            SetSoundChange();
        } else if (soundType == "SFXSlider") 
        { 
            _audioSFX = newValue;
        }
    }

    public void SetSoundChange()
    {
        AudioSource[] audios = _camera.GetComponents<AudioSource>();
        foreach (AudioSource audio in audios)
        {
            audio.volume = _audioVolume * _audioMusic;
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
            _camera = Camera.main;
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
