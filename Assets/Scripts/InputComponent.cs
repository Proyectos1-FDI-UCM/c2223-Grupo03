using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    #region references
    private Inventory _inventory;
    #endregion

    //cosas de pablo
    [SerializeField] private GameObject _clockPrefab; 
    private GameObject _clock;
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
        _inventory = gameObject.GetComponent<Inventory>();
    }

    void Update()
    {
        _movementComponent.ChangeValues(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _heartDetection.SpacePressed();
        }
        if (Input.GetKeyDown(KeyCode.J) && _inventory._pildoraEquipado) //A�ADIR CONDICION DE TENERLA EN EL INVENTARIO
        {
            _playerStates.PillEffect();
        }

        // If the player presses the "K" key, change between the player and the box 
        if (Input.GetKeyDown(KeyCode.K) && _inventory._cajaEquipado)
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

        if (Input.GetKeyDown(KeyCode.L) && _inventory._DespertadorEquipado)
        {
            //_inventory.EliminaObjeto(3);
            _clock = Instantiate(_clockPrefab, GameManager.Player.transform.position, new Quaternion(0,0,0,0));
            _clock.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            _clock.GetComponent<ClockDistractionComponent>().SetInstance = true;
        }

    }
}
