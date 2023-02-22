using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Instance para poder coger variables del gamemanager
    static private GameManager _instance;
    static public GameManager Instance { get { return _instance; } }

    //referencia al player
    static private GameObject _player;
    static public GameObject Player { get { return _player; } }


    #region methods



    #endregion




    void Awake()
    {
        _instance = this;
        _player = GameObject.Find("Player");
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
