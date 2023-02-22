using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region parameters

    [SerializeField]
    private float _timeOutPill = 10;

    #endregion

    #region references
    [SerializeField]
    private GameObject _warning;
    [SerializeField]
    private GameObject _heart;
    [SerializeField]
    private GameObject _safeZone;
    [SerializeField]
    private GameObject _UIManager;

    #endregion


    #region properties

    // Instance para poder coger variables del gamemanager
    static private GameManager _instance;
    static public GameManager Instance { get { return _instance; } }

    //referencia al player
    static private GameObject _player;
    static public GameObject Player { get { return _player; } }

    private bool _withEffect = false;

    public bool WithEffect
    {
        get 
        { 
            return _withEffect; 
        }
    }
    #endregion

    #region methods

    public void PillEffect ()
    {
        if (!_withEffect)
        {
            _heart.GetComponent<HeartMove>().enabled = false;
            _safeZone.GetComponent<ProximityComponent>().enabled = false;
            _warning.GetComponent<Image>().color = new Color(0, 1, 0, 0.25f);
            _warning.SetActive(true);
            _UIManager.GetComponent<UIManager>().FlickerEffect(_warning);
            Invoke("ActiveHeart", _timeOutPill);
            //QUITAR PASTILLA DEL INVENTARIO
            _withEffect = true;
        }
    }

    private void Flicker()
    {

    }

    private void ActiveHeart()
    {
        _heart.GetComponent<HeartMove>().enabled = true;
        _safeZone.GetComponent<ProximityComponent>().enabled = true;
        _withEffect = false;
    }

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
