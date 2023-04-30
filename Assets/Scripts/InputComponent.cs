using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    //cosas de pablo
    
    //cosas de pablo
    
    #region Properties

    #endregion

    #region Parameters
    private GameObject _player;

    #endregion

    #region References
    [SerializeField] private GameObject _heart;
    [SerializeField] private GameObject _playerInCloset;
    private HeartDetection _heartDetection;
    private MovementComponent _movementComponent;
    private Inventory _inventory;
    private InputDelay _inputDelay;


    private PlayerStates _playerStates;
    #endregion

    void Start()
    {
        _player = GameManager.Player;
        _playerStates = _player.GetComponent<PlayerStates>();
        _heartDetection = _heart.GetComponent<HeartDetection>();
        _inventory = GameManager.Instance.GetComponent<Inventory>();
        _movementComponent = GameManager.Player.GetComponent<MovementComponent>();
        _inputDelay = gameObject.GetComponent<InputDelay>();
    }

    void Update()
    {
        _movementComponent.ChangeValues(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButton("R1Ps4")))
        {
            _heartDetection.SpacePressed();
        }
        if (((Input.GetKeyDown(KeyCode.J) || Input.GetButton("CuadradoPs4")) && _inventory._pildoraEquipado && !GameManager.PlayerStates.Tired) && _inputDelay.TryInput()) //A�ADIR CONDICION DE TENERLA EN EL INVENTARIO
        {
            _playerStates.PillEffect();
        }

        // If the player presses the "K" key, change between the player and the box 

        if (((Input.GetKeyDown(KeyCode.K) || Input.GetButton("TrianguloPs4")) && _inventory._cajaEquipado && !GameManager.PlayerStates.Tired) && _inputDelay.TryInput() && _playerInCloset.activeSelf == false)
        {
            if (_playerStates.IsBox)
            {
                _playerStates.ExitBox();
            }
            else
            {
                _playerStates.EnterBox();
                _playerInCloset.SetActive(false);
            }
        }
        if ((Input.GetKeyDown(KeyCode.L) || Input.GetButton("CirculoPs4")) && _inventory._DespertadorEquipado && !GameManager.PlayerStates.Tired)
        {
            _playerStates.Clock();
        }
    }
}
