using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityComponent : MonoBehaviour
{
    //Script que se encarga de de cambiar el tamaño de la zona segura según el estado que se le envie

    #region parameters

    [SerializeField]
    private float _sizeSpeed = 0.01f; //Velocidad en la que aumenta la barra o disminuye

    private float _lessDistance = 20; //La distancia más baja registrada por el momento

    private float _size; //El tamaño al que debe ir la barra

    #endregion

    #region properties

    private GameObject _closest; //El enemigo más cercano al jugador

    #endregion

    #region methods


    public void ChangeToScale(float distance, GameObject closeEnemy) //Método para calcular la escala a la que debe aproximarse la zona segura según la distancia al enemigo
    {

        if (distance < _lessDistance) //Para aquellos enemigos que reduzcan la distancia mínima
        {
            _closest = closeEnemy; //Se les pone como nuevos enemigos más cercanos
            _lessDistance = distance; //La distancia mínima se actualiza

            if(distance < 13 && distance > 2.88) //Si la distancia esta entre los valores extremos
            {
                _size = (distance * 9) / 13; //Se hace una regla de tres para calcular el tamaño respecto a la distancia
            }
            else if (distance >= 13) //Si la distancia es mayor de la máxima se pone el tope en tamaño 9
            {
                _size = 9;
            }
            else if (distance <= 2.88) //Si la distancia es menor de la mínima se pone el tope bajo en tamaño 2
            {
                _size = 2;
            }
            
        }
        else if (distance > _lessDistance && closeEnemy == _closest) //Si el enemigo esta a más distancia de la mínima solo nos interesa si es el más cercano, se hace lo mismo excepto el atribuir el enemigo más cercano
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

        if (transform.localScale.x > _size) //Si el tamaño es mayor del debido se reduce
        {
            transform.localScale += new Vector3(-_sizeSpeed, 0, 0); //Sirve para disminuir el tamaño de la barra 
        }
        else if (transform.localScale.x < _size) //Si el tamaño es menor al debido se aumenta
        {
            transform.localScale += new Vector3(+_sizeSpeed, 0, 0); //Sirve para aumentar el tamaño de la barra 
        }

    }
}
