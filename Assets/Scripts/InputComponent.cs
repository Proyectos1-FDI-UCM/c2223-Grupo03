using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{

    #region properties
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




    void Start()
    {
        _player = GameManager.Player;
        _isBox = false;
        _heartDetection = _heart.GetComponent<HeartDetection>();
        _movementComponent = GameManager.Player.GetComponent<MovementComponent>();
    }

    void Update()
    {
        _movementComponent.ChangeValues(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _heartDetection.SpacePressed();
        }
        if (Input.GetKeyDown(KeyCode.J)) 
        {
            if (GameManager.Instance.GetComponent<Inventory>()._PildoraEquipado)
                GameManager.PlayerStates.PillEffect();
        }

        // If the player presses the "K" key, change between the player and the box 
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (_isBox)
            {
                Destroy(_box);
                _player.SetActive(true);
                _isBox = false;
            }
            else
            {
                _player.SetActive(false);
                _box = Instantiate(_boxPrefab, _player.transform.position, Quaternion.identity);
                _isBox = true;
            }
        }

    }
}
