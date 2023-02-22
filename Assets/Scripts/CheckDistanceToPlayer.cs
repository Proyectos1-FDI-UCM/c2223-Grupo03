using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDistanceToPlayer : MonoBehaviour
{
    //Script atachado a los enemigos encargado de comprobar en todo momento su distancia con el jugador

    #region references

    [SerializeField]
    private GameObject _player; //Jugador

    [SerializeField]
    private GameObject _safeZone; //Zona segura la cual deben cambiar

    #endregion



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        _safeZone.GetComponent<ProximityComponent>().ChangeToScale(Vector3.Distance(_player.transform.position, transform.position), gameObject); //Se envia una nueva distancia a la zona segura para que cambie su tamaño segun esa distancia

    }
}
