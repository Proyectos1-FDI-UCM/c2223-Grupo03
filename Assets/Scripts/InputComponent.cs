using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{

    #region Properties
    [SerializeField] private GameObject _heart;
    private HeartDetection _heartDetection;
    private MovementComponent _movementComponent;
    #endregion

    #region Parameters
    [SerializeField] private GameObject _boxPrefab;
    private GameObject _player;
    private GameObject _box;
    private bool _isBox;
    public bool IsBox { get { return _isBox; } }
    #endregion

    #region References
    private Inventory _inventory;
    #endregion

    void Start()
    {
        _player = GameManager.Player;
        _isBox = false;
        _heartDetection = _heart.GetComponent<HeartDetection>();
        _movementComponent = GameManager.Player.GetComponent<MovementComponent>();
        _inventory = GetComponent<Inventory>();
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
            //GameManager.Instance.PillEffect();
            Debug.Log("hola");
            _inventory._pildoraEquipado = false;
            _inventory.EliminaObjeto(1);
        }

        // If the player presses the "K" key, change between the player and the box 
        if (Input.GetKeyDown(KeyCode.K) && _inventory._cajaEquipado)
        {
            if (_isBox)
            {
                Debug.Log("iiiii");
                Destroy(_box);
                _player.SetActive(true);
                _isBox = false;
                _inventory._cajaEquipado = false;
                _inventory.EliminaObjeto(2);
            }
            else
            {
                _player.SetActive(false);
                _box = Instantiate(_boxPrefab, _player.transform.position, Quaternion.identity);
                _isBox = true;
                Debug.Log(_isBox);
            }
        }

    }
}
