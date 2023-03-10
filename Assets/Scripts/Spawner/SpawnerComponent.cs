using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour
{
    public GameObject _objectPrefab;
    private GameObject _spawnedObject;
    [SerializeField] public float _spawnDelay = 2f;

    private void Start()
    {
        SpawnObject();
    }

    public void SpawnObject()
    {
        if (_spawnedObject == null)
        {
            _spawnedObject = Instantiate(_objectPrefab, transform.position, Quaternion.identity);
            _spawnedObject.GetComponent<ObjectController>().SetSpawner(this);
        }
    }

    public void ObjectHasBeenCollected()
    {
        _spawnedObject = null;
        Invoke("SpawnObject", _spawnDelay);
    }
}





