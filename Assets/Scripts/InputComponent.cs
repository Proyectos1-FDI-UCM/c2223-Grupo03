using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{

    #region properties

    [SerializeField]
    private GameObject _heart;

    #endregion


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _heart.GetComponent<HeartDetection>().SpacePressed();
        }
        if (Input.GetKeyDown(KeyCode.J)) //AÑADIR CONDICION DE TENERLA EN EL INVENTARIO
        {
            GameManager.Instance.PillEffect();
        }

    }
}
