using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

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
    private HeartDetection _heartDetection;
    private MovementComponent _movementComponent;
    private Inventory _inventory;


    private PlayerStates _playerStates;
    #endregion

    void Start()
    {
        _player = GameManager.Player;
        _playerStates = _player.GetComponent<PlayerStates>();
        _heartDetection = _heart.GetComponent<HeartDetection>();
        _inventory = GameManager.Instance.GetComponent<Inventory>();
        _movementComponent = GameManager.Player.GetComponent<MovementComponent>();
    }

    void Update()
    {
        var gamepad = Gamepad.current;

        //Vector2 movementInput = gamepad.leftStick.ReadValue();


        Vector2 movement = Vector2.zero;

        if (Gamepad.current != null && Gamepad.current.leftStick.ReadValue() != Vector2.zero)
        {
            // Si se está utilizando un controlador, leer la entrada del stick izquierdo
            movement = Gamepad.current.leftStick.ReadValue();
        }
        else
        {
            // Si no se está utilizando un controlador, leer la entrada del teclado
            movement.x = Keyboard.current.dKey.ReadValue() - Keyboard.current.aKey.ReadValue();
            movement.y = Keyboard.current.wKey.ReadValue() - Keyboard.current.sKey.ReadValue();
        }
        _movementComponent.ChangeValues(movement);

        if (Keyboard.current[Key.Space].wasPressedThisFrame || Gamepad.current[GamepadButton.RightShoulder].wasPressedThisFrame)
        {
            _heartDetection.SpacePressed();
        }

        if ((Keyboard.current[Key.J].wasPressedThisFrame || Gamepad.current[GamepadButton.X].wasPressedThisFrame) && _inventory._pildoraEquipado) //A�ADIR CONDICION DE TENERLA EN EL INVENTARIO
        {
            _playerStates.PillEffect();
        }

        // If the player presses the "K" key, change between the player and the box 

        if ((Keyboard.current[Key.K].wasPressedThisFrame || Gamepad.current[GamepadButton.Y].wasPressedThisFrame) && _inventory._cajaEquipado && !GameManager.PlayerStates.Tired)
        {
            if (_playerStates.IsBox)
            {
                _playerStates.ExitBox();
            }
            else
            {
                _playerStates.EnterBox();
            }
        }

        if ((Keyboard.current[Key.L].wasPressedThisFrame || Gamepad.current[GamepadButton.B].wasPressedThisFrame) && _inventory._DespertadorEquipado && !GameManager.PlayerStates.Tired)
        {
            _playerStates.Clock();
        }
    }
}
