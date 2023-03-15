using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab;
    public bool _spawnedObject = false;
    [SerializeField] public float _spawnDelay = 2f;
    private Inventory _inventory;
    private ObjectController _objectController;
    public bool _boxPicked = false;


    private void Start()
    {
        _spawnedObject = Instantiate(_objectPrefab, transform.position, Quaternion.identity);
        _inventory = GameManager.Instance.GetComponent<Inventory>();
        _objectController = GameManager.Player.GetComponent<ObjectController>();
    }

    public void SpawnObject()
    {
 
        _spawnedObject = Instantiate(_objectPrefab, transform.position, Quaternion.identity);
       
    }

    public void ObjectHasBeenCollected()
    {
        Invoke("SpawnObject", _spawnDelay);
        _boxPicked = false;

    }
}





