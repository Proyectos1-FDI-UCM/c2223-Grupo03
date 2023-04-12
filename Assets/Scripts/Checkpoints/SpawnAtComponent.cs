using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAtComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        if (!GameManager.Instance.getSpawn.getCP())
        {
            GameManager.Player.transform.position = transform.GetChild(0).transform.position;
        }
        else
        {
            GameManager.Player.transform.position = transform.GetChild(1).transform.position;
            Destroy(GameObject.Find("Llave"));
            GameManager.Instance.GetComponent<Inventory>().AñadeObjeto(4);
        }
    }
}
