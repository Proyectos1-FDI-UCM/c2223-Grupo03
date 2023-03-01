using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    #region references
    private Inventory _inventory;
    #endregion

    #region properties
    [SerializeField] private GameObject _heart;
    private HeartDetection _heartDetection;
    private MovementComponent _movementComponent;

    private GameObject _closet;
    [SerializeField] private GameObject _boxPrefab;
    private GameObject _player;
    private GameObject _box;
    private bool _isBox;

    [SerializeField] private GameObject _clockPrefab; 
    private GameObject _clock;
    #endregion

    void Start()
    {
        _player = GameManager.Player;
        _isBox = false;
        _closet = GameObject.Find("Closet");
        _heartDetection = _heart.GetComponent<HeartDetection>();
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
        if (Input.GetKeyDown(KeyCode.J) && _inventory._PildoraEquipado) //AÑADIR CONDICION DE TENERLA EN EL INVENTARIO
        {
            GameManager.Instance.PillEffect();
            _inventory.EliminaObjeto(1);
        }

        // If the player presses the "K" key, change between the player and the box 
        if (Input.GetKeyDown(KeyCode.K) && _inventory._CajaEquipado)
        {
            if (_isBox)
            {
                Destroy(_box);
                _closet.GetComponent<ClosetComponent>().enabled = true;
                _player.SetActive(true);
                _isBox = false;
            }
            else
            {
                _player.SetActive(false);
                _box = Instantiate(_boxPrefab, _player.transform.position, Quaternion.identity);
                _closet.GetComponent<ClosetComponent>().enabled = false;
                _isBox = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.L) && _inventory._DespertadorEquipado)
        {
            //_inventory.EliminaObjeto(3);
            _clock = Instantiate(_clockPrefab, GameManager.Player.transform.position, new Quaternion(0,0,0,0));
            _clock.GetComponent<ClockDistractionComponent>().SetInstance = true;
        }

    }
}
