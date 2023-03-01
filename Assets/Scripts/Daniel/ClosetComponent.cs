using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetComponent : MonoBehaviour
{

    #region Parameters
    [SerializeField] private float _interactDistance;
    private bool _isHiding = false;
    private Vector2 _playerPos;
    private Vector2 _closetPos;
    private GameObject _player;
    private GameObject _closet;
    #endregion

    #region Methods

    //Comptueba si el juagr esta dentro del rango poara entrar en el armario
    private bool CanHide()
    {
        _playerPos = _player.transform.position;
        _closetPos = _closet.transform.position;
        if (Vector2.Distance(_playerPos, _closetPos) <= _interactDistance)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    //Esconde al jugador
    private void HidePlayer()
    {
        _player.SetActive(false);
        _isHiding = true;
    }

    //Muestra al jugador
    private void ShowPlayer()
    {
        _player.SetActive(true);
        _isHiding = false;
    }

    private void Start()
    {
        _closet = gameObject;
        _player = GameManager.Player;
    }
    // Update is called once per frame
    void Update()
    {
        if (CanHide() && Input.GetKeyDown(KeyCode.E) && !GameManager.InputComponent.IsBox)
        {
            if (!_isHiding)
            {
                HidePlayer();
            }
            else
            {
                ShowPlayer();
            }
        }
    }
    #endregion
}
