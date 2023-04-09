using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDistanceToPlayer : MonoBehaviour
{
    //Script atachado a los enemigos encargado de comprobar en todo momento su distancia con el jugador

    #region references

    private GameObject _player; //Jugador

    private GameObject _safeZone; //Zona segura la cual deben cambiar
    private ProximityComponent _ProximityComponent;
    #endregion



    // Start is called before the first frame update
    void Start()
    {
        _player = GameManager.Player;
        _safeZone = GameObject.Find("SafeZone");
        _ProximityComponent = _safeZone.GetComponent<ProximityComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Se envia una nueva distancia a la zona segura para que cambie su tamaño segun esa distancia
        if (_ProximityComponent != null)
        {
            _ProximityComponent.ChangeToScale(Vector3.Distance(_player.transform.position, transform.position), gameObject);
        }
            
    }
}
