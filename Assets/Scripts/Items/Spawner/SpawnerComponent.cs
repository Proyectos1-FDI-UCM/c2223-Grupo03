using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab;
    public GameObject _spawnedObject;
    [SerializeField] public float _spawnDelay = 2f;
    public bool _boxPicked;


    private void Start()
    {
        _spawnedObject = Instantiate(_objectPrefab, transform.position, Quaternion.identity);
    }

    public void SpawnObject()
    {
        if (_spawnedObject == null)
        {
            _spawnedObject = Instantiate(_objectPrefab, transform.position, Quaternion.identity);
        }
          
    }

    public void ObjectCollected()
    {
       
       Invoke("SpawnObject", _spawnDelay);
        
       
    } 

    private void Update()
    {
        if(_spawnedObject == null)
        {
            ObjectCollected();
        }
    }
}





