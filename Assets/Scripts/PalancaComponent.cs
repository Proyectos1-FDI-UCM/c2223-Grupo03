using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalancaComponent : MonoBehaviour
{
    #region references

    [SerializeField] GameObject _deleteEnemy;

    #endregion

    #region properties

    Transform _newPosition;

    #endregion

    #region methods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameManager.Player)
        {
            _deleteEnemy.SetActive(false);
            collision.gameObject.transform.position = _newPosition.position;
            Destroy(gameObject);
        }
    }

    #endregion


    void Start()
    {
        _newPosition = transform.GetChild(0).transform;
    }


}
