using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoorComponent : MonoBehaviour
{
    Inventory _inventory;
    void Start()
    {
        _inventory = GameManager.Instance.GetComponent<Inventory>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && _inventory._LlaveEquipado)
        {
            Destroy(gameObject);
        }
    }
}
