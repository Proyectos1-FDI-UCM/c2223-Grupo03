using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HeartDetection : MonoBehaviour
{
    //El Script se encarga de recibir el input del espacio pulsado y procesarlo según la situación del corazón respecto a la barra de seguridad

    #region references

    [SerializeField]
    private GameObject _safeZone; //Zona verde en la que el jugador debe pulsar

    [SerializeField]
    private GameObject _warning; //Panel rojo claro que avisa si se entra en la zona verde

    #endregion

    #region parameters

    private int _fails; //Numero de fallos

    #endregion

    #region properties

    private bool _inSafeZone = false; //Se activa si se esta en la zona verde y se desactiva al salir de ella
    private bool _hasPressed = false; //Se activa al presionar el espacio una vez y se desactiva al botar, iniciando asi un nuevo proceso

    #endregion


    #region methots

    public void SpacePressed() //Metodo que se activa al pulsar el espacio y realiza acciones diferentes segun el estado del corazón respecto a la barra de pulsaciones
    {

        if (!_hasPressed) //Si ya se ha presionado espacio en esa vuelta no hace nada
        {
            if (!_inSafeZone) //Si no esta en la zona segura
            {
                _fails++; //Aumenta en uno los fallos
                //Debug.Log(_fails);
                _hasPressed = true; //Se activa el bool de pulsado
            }
            else
            {
                _hasPressed = true; //Se activa el bool de pulsado
                GetComponent<Image>().color = new Color(1, 0, 0, 1); //Cambia el color del corazón para dar feedback al jugador
                _warning.SetActive(false); //Desactiva el panel de aviso para dar feedback al jugador
            }
        }
        
    }

    public void ResetValues() //Al haber dado una vuelta se activa este metodo para restablecer valores al estado original
    {
        GetComponent<Image>().color = new Color(0, 0, 1, 1); //Cambia el color del corazón
        _hasPressed = false; //Se reestablece el bool de presionado
    }

    private void OnTriggerEnter2D(Collider2D collision) //Metodo que comprueba que se haya entrado a la zona segura
    {

        if (collision.gameObject == _safeZone) //Si el trigger es el de la zona segura
        {
            _warning.SetActive(true); //Se activa el panel de aviso
            _inSafeZone = true; //El bool de zona segura se activa
        }
    }

    private void OnTriggerExit2D(Collider2D other) //Metodo que comprueba que se ha salido de la zona segura
    {

        if (other.gameObject == _safeZone) //Si el trigger es el de la zona segura
        {
            _warning.SetActive(false); //Se desactiva el panel de aviso
            _inSafeZone = false; //Se muestra que ya no se esta en la zona segura

            if (!_hasPressed) //Si no se a presionado el espacio quiere decir que se ha saltado la zona sagura y por tanto es un fallo
            {
                _fails++;
            }
        }
    }

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        _warning.SetActive(false); //Se desactiva el panel de aviso de primeras
    }

    // Update is called once per frame
    void Update()
    {
        if (_fails == 3) //Se comprueba si se ha llegado a 3 fallos
        {
            //DECIR AL GAMEMANAGER QUE DESACTIVE EL INPUT DEL JUGADOR
            _fails = 0; //Se reestablecen los fallos
        }
    }
}
