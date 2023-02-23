using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityComponent : MonoBehaviour
{
    //Script que se encarga de de cambiar el tama�o de la zona segura seg�n el estado que se le envie

    #region parameters

    [SerializeField]
    private float _sizeSpeed = 0.01f; //Velocidad en la que aumenta la barra o disminuye

    private float _lessDistance = 20; //La distancia m�s baja registrada por el momento

    private float _size; //El tama�o al que debe ir la barra

    #endregion

    #region properties

    private GameObject _closest; //El enemigo m�s cercano al jugador

    #endregion

    #region methods


    public void ChangeToScale(float distance, GameObject closeEnemy) //M�todo para calcular la escala a la que debe aproximarse la zona segura seg�n la distancia al enemigo
    {

        if (distance < _lessDistance) //Para aquellos enemigos que reduzcan la distancia m�nima
        {
            _closest = closeEnemy; //Se les pone como nuevos enemigos m�s cercanos
            _lessDistance = distance; //La distancia m�nima se actualiza

            if(distance < 13 && distance > 2.88) //Si la distancia esta entre los valores extremos
            {
                _size = (distance * 9) / 13; //Se hace una regla de tres para calcular el tama�o respecto a la distancia
            }
            else if (distance >= 13) //Si la distancia es mayor de la m�xima se pone el tope en tama�o 9
            {
                _size = 9;
            }
            else if (distance <= 2.88) //Si la distancia es menor de la m�nima se pone el tope bajo en tama�o 2
            {
                _size = 2;
            }
            
        }
        else if (distance > _lessDistance && closeEnemy == _closest) //Si el enemigo esta a m�s distancia de la m�nima solo nos interesa si es el m�s cercano, se hace lo mismo excepto el atribuir el enemigo m�s cercano
        {
            _lessDistance = distance;

            if (distance < 13 && distance > 2.88)
            {
                _size = (distance * 9) / 13;
            }
            else if (distance >= 13)
            {
                _size = 9;
            }
            else if (distance <= 2.88)
            {
                _size = 2;
            }

        }

    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.localScale.x > _size) //Si el tama�o es mayor del debido se reduce
        {
            transform.localScale += new Vector3(-_sizeSpeed, 0, 0); //Sirve para disminuir el tama�o de la barra 
        }
        else if (transform.localScale.x < _size) //Si el tama�o es menor al debido se aumenta
        {
            transform.localScale += new Vector3(+_sizeSpeed, 0, 0); //Sirve para aumentar el tama�o de la barra 
        }

    }
}
