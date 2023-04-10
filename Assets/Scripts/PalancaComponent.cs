using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalancaComponent : MonoBehaviour
{
    #region references

    [SerializeField] public GameObject _deleteEnemy;
    [SerializeField] GameObject _checkpointManager;

    #endregion

    #region properties

    Transform _newPosition;
    [SerializeField] private int _numPalanca;
    public bool _palancaActive = false;

    #endregion

    #region methods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameManager.Player)
        {
            _palancaActive = true;
            _deleteEnemy.SetActive(false);
            collision.gameObject.transform.position = _newPosition.position;
            gameObject.SetActive(false);
        }
        else
        {
            _palancaActive = false;
        }
    }

    #endregion


    void Start()
    {
        _newPosition = transform.GetChild(0).transform;
    }


}
