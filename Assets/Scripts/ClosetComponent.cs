using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetComponent : MonoBehaviour
{

    #region Variables
    [SerializeField] private float _interactDistance;
    private bool _isHiding = false;
    private Vector2 _playerPos;
    private Vector2 _closetPos;
    [SerializeField] private GameObject _player;
    #endregion

    #region Methods

    private bool CanHide()
    {
        _playerPos = _player.transform.position;
        _closetPos = transform.position;
        if (Vector2.Distance(_playerPos, _closetPos) <= _interactDistance)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    private void HidePlayer()
    {
        _player.SetActive(false);
        _isHiding = true;
    }

    private void ShowPlayer()
    {
        _player.SetActive(true);
        _isHiding = false;
    }

    #endregion

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
}
