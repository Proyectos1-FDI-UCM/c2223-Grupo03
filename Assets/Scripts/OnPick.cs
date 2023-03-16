using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OnPick : MonoBehaviour
{
    [SerializeField] private int _id;
    Inventory _Inventory;


    private void Start()
    {
        _Inventory = GameManager.Instance.GetComponent<Inventory>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (_id == 1 && !_Inventory._PildoraEquipado)
            {
                _Inventory.A�adeObjeto(_id);
                Destroy(gameObject);
                
            }
            else if (_id == 2 && !_Inventory._CajaEquipado) 
            {
                _Inventory.A�adeObjeto(_id);
                Destroy(gameObject);

            }
            else if (_id == 3 && !_Inventory._DespertadorEquipado) 
            {
                _Inventory.A�adeObjeto(_id);
                Destroy(gameObject);

            }
            else if (_id == 4 && !_Inventory._LlaveEquipado)
            {
                _Inventory.A�adeObjeto(_id);
                Destroy(gameObject);
            }
      
         
        }
    }
}

