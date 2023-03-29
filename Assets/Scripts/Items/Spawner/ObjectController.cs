using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] GameObject _spawner;
    private SpawnerComponent _spawnerComp;
    private Inventory _inventory;
    public bool _boxPicked = false;


    private void Start()
    {
        _inventory = GameManager.Instance.GetComponent<Inventory>();
        _spawnerComp = _spawner.GetComponent<SpawnerComponent>();
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Spawner")
        {
            Debug.Log("choca");
            //Aquí es donde se detecta que el objeto ha sido recogido por el jugador
            if (_boxPicked == false || _inventory._cajaEquipado)
            {
                Debug.Log("hola");
                _boxPicked = true;
                
                _spawnerComp.ObjectCollected();

            }


        }
    }
}