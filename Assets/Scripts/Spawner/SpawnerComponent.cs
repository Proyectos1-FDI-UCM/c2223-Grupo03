using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab;
    public GameObject _spawnedObject;
    [SerializeField] public float _spawnDelay = 2f;
    private Inventory _inventory;
    private ObjectController _objectController;
    public bool _boxPicked;


    private void Start()
    {
        _spawnedObject = Instantiate(_objectPrefab, transform.position, Quaternion.identity);
        _inventory = GameManager.Instance.GetComponent<Inventory>();
        _objectController = GameManager.Player.GetComponent<ObjectController>();
        _boxPicked = false;
    }

    public void SpawnObject()
    {
        if (_spawnedObject == null)
        {
            _spawnedObject = Instantiate(_objectPrefab, transform.position, Quaternion.identity);
            _boxPicked = false;
        }
          
    }

    public void ObjectCollected()
    {
       
       Invoke("SpawnObject", _spawnDelay);
        
       
    } 
}





