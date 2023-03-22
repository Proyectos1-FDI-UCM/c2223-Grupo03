using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region parameters

    
    #endregion

    #region references


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
    

    #endregion

    #region methods

    

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

    }
    void Update()
    {

    }
}
