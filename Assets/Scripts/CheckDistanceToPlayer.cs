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
        
        if (Vector3.Distance(_player.transform.position, transform.position) > 13) //Se comprueba la distancia al jugador una a una (Se pueden poner los parametros referenciados para mayor comodidad para alterarlos)
        {
            _safeZone.GetComponent<ProximityComponent>().ChangeSafeZoneState(0); //Se envia un nuevo estado a la zona segura para que cambie su tamaño segun ese estado
        }
        else if (Vector3.Distance(_player.transform.position, transform.position) > 10)
        {
            _safeZone.GetComponent<ProximityComponent>().ChangeSafeZoneState(1);
        }
        else if (Vector3.Distance(_player.transform.position, transform.position) > 5)
        {
            _safeZone.GetComponent<ProximityComponent>().ChangeSafeZoneState(2);
        }
        else if (Vector3.Distance(_player.transform.position, transform.position) > 2)
        {
            _safeZone.GetComponent<ProximityComponent>().ChangeSafeZoneState(3);
        }

    }
}
