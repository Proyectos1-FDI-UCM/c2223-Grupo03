using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ClosetComponent : MonoBehaviour
{

    #region Parameters
    [SerializeField] private float _interactDistance;
    private bool _isHiding = false;
    private Vector2 _playerPos;
    private Vector2 _closetPos;
    [SerializeField] private GameObject _player;
    [SerializeField] private Sprite _closet;
    [SerializeField] private Sprite _closetShine;
    #endregion

    #region Methods

    //Comptueba si el juagr esta dentro del rango poara entrar en el armario
    private bool CanHide()
    {
        _playerPos = _player.transform.position;
        _closetPos = transform.position;
        if (Vector2.Distance(_playerPos, _closetPos) <= _interactDistance)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _closetShine;
            return true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _closet;
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


    // Update is called once per frame
    void Update()
    {
        if (CanHide() && Input.GetKeyDown(KeyCode.E))
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
