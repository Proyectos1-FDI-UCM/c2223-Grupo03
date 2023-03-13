using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private SpawnerComponent _spawnerComp;
    private Inventory _inventory;


    private void Start()
    {
        _inventory = GameManager.Instance.GetComponent<Inventory>();
    }


    public void SetSpawner(SpawnerComponent newSpawner)
    {
        _spawnerComp = newSpawner;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //Aquí es donde se detecta que el objeto ha sido recogido por el jugador
            if (_spawnerComp != null)
            {
                _spawnerComp.ObjectHasBeenCollected();
            }

        }
    }
}