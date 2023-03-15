using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour
{
    public GameObject _objectPrefab;
    private GameObject _spawnedObject;
    [SerializeField] public float _spawnDelay = 2f;
    private Inventory _inventory;
    private bool _boxspawned = true;



    private void Start()
    {
        SpawnObject();
        _inventory = GameManager.Instance.GetComponent<Inventory>();
    }

    public void SpawnObject()
    {
        if (_spawnedObject == null)
        {
            _boxspawned = true;
            _spawnedObject = Instantiate(_objectPrefab, transform.position, Quaternion.identity);
            _spawnedObject.GetComponent<ObjectController>().SetSpawner(this);
        }
    }

    public void ObjectHasBeenCollected()
    {
        if (_inventory._CajaEquipado && _spawnedObject == null && _boxspawned == false)
        {
            _boxspawned = false;
            _spawnedObject = null;
            Invoke("SpawnObject", _spawnDelay);
        }
       
    }
}





