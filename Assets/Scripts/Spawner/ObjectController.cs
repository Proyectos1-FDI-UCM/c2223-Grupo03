using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private SpawnerComponent _spawnerComp;


    public void SetSpawner(SpawnerComponent newSpawner)
    {
        _spawnerComp = newSpawner;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Aquí es donde se detecta que el objeto ha sido recogido por el jugador
            if (_spawnerComp != null)
            {
                _spawnerComp.ObjectHasBeenCollected();
            }

        }
    }
}