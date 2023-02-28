using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            _Inventory.AñadeObjeto(_id);
            Destroy(gameObject);
        }
    }
}

