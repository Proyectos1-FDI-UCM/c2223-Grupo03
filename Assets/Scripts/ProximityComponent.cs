using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityComponent : MonoBehaviour
{
    //Script que se encarga de de cambiar el tamaño de la zona segura según el estado que se le envie

    #region parameters

    [SerializeField]
    private float _sizeSpeed = 0.01f; //Velocidad en la que aumenta la barra o disminuye

    private int _state; //Estados de la barra y el tamaño de su posición en la y se pone abajo
    /*
     * Estado 0 = 8,36
     * Estado 1 = 6,06
     * Estado 2 = 4,17
     * Estado 3 = 2,19 
     */

    #endregion

    #region methods

    public void ChangeSafeZoneState(int newState) //Se encarga de cambiar el estado según le marquen (Aún falta refinarlo para cuando hay varios enemigos pero eso ya lo hare YO) Adrián
    {
        _state = newState;
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (_state == 3) //Se van comprobando uno a uno los estados y cambai el tamaño según el estado actual
        {
            if (transform.localScale.x > 2.12) //Si el tamaño es mayor del debido se reduce
            {
                transform.localScale += new Vector3(-_sizeSpeed, 0, 0); //Sirve para disminuir el tamaño de la barra 
            }
            else if (transform.localScale.x < 2.12) //Si el tamaño es menor al debido se aumenta
            {
                transform.localScale += new Vector3(+_sizeSpeed, 0, 0); //Sirve para aumentar el tamaño de la barra 
            }
        }
        else if (_state == 2)
        {
            if (transform.localScale.x > 4.17)
            {
                transform.localScale += new Vector3(-_sizeSpeed, 0, 0);
            }
            else if (transform.localScale.x < 4.17)
            {
                transform.localScale += new Vector3(+_sizeSpeed, 0, 0);
            }
        }
        else if (_state == 1)
        {
            if (transform.localScale.x > 6.06)
            {
                transform.localScale += new Vector3(-_sizeSpeed, 0, 0);
            }
            else if (transform.localScale.x < 6.06)
            {
                transform.localScale += new Vector3(+_sizeSpeed, 0, 0);
            }
        }
        else if (_state == 0)
        {
            if (transform.localScale.x > 8.16)
            {
                transform.localScale += new Vector3(-_sizeSpeed, 0, 0);
            }
            else if (transform.localScale.x < 8.16)
            {
                transform.localScale += new Vector3(+_sizeSpeed, 0, 0);
            }
        }

    }
}
