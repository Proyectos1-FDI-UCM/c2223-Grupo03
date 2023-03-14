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

    [SerializeField] bool DEBUG;
    private int _fails; //Numero de fallos

    #endregion

    #region properties

    private bool _inSafeZone = false; //Se activa si se esta en la zona verde y se desactiva al salir de ella
    private bool _hasPressed = false; //Se activa al presionar el espacio una vez y se desactiva al botar,
                                      //iniciando asi un nuevo proceso
    public bool _pillEffects = false;

    private AudioSource _beepSound;

    [SerializeField] private Sprite _brokenHeart3;
    [SerializeField] private Sprite _brokenHeart2;
    [SerializeField] private Sprite _brokenHeart1;
    [SerializeField] private Sprite _normalHeart;
    [SerializeField] private Sprite _safeHeart;

    private Image _currentImage;
    #endregion


    #region methots

    public void SpacePressed() //Metodo que se activa al pulsar el espacio y realiza acciones diferentes segun el estado del corazón respecto a la barra de pulsaciones
    {

        if (!_hasPressed) //Si ya se ha presionado espacio en esa vuelta no hace nada
        {

            if (!_inSafeZone) //Si no esta en la zona segura
            {
                Debug.Log("Fallo al presionar");
                _fails++; //Aumenta en uno los fallos
                if (_fails == 1)
                    _currentImage.sprite = _brokenHeart1;
                if (_fails == 2)
                    _currentImage.sprite = _brokenHeart2;
                if (_fails == 3)
                    _currentImage.sprite = _brokenHeart3;
                _hasPressed = true; //Se activa el bool de pulsado
            }
            else if (_fails < 3)
            {
                _hasPressed = true; //Se activa el bool de pulsado
                _currentImage.sprite = _safeHeart;
                if (!GameManager.PlayerStates.WithEffect)
                {
                    _warning.GetComponent<Image>().color = new Color(0, 0, 0, 0); //Desactiva el panel de aviso para dar feedback al jugador
                }
                 
            }
        }
        
    }

    public void ResetValues() //Al haber dado una vuelta se activa este metodo para restablecer valores al estado original
    {
        if (_currentImage.sprite == _safeHeart || _currentImage.sprite == _brokenHeart3)
            _currentImage.sprite = _normalHeart;
        _hasPressed = false; //Se reestablece el bool de presionado
    }

    private void OnTriggerEnter2D(Collider2D collision) //Metodo que comprueba que se haya entrado a la zona segura
    {

        if (collision.gameObject == _safeZone) //Si el trigger es el de la zona segura
        {
            _beepSound.Play();
            _warning.GetComponent<Image>().color = new Color(1, 0, 0, 0.20f); //Se activa el panel de aviso
            _inSafeZone = true; //El bool de zona segura se activa
        }
    }

    private void OnTriggerExit2D(Collider2D other) //Metodo que comprueba que se ha salido de la zona segura
    {

        if (other.gameObject == _safeZone) //Si el trigger es el de la zona segura
        {
            _warning.GetComponent<Image>().color = new Color(0, 0, 0, 0); //Se desactiva el panel de aviso
            _inSafeZone = false; //Se muestra que ya no se esta en la zona segura

            if (!_hasPressed && !_pillEffects) //Si no se a presionado el espacio quiere decir que se ha saltado la zona segura y por tanto es un fallo
            {
                Debug.Log("Fallo por salida");
                _fails++;
                _hasPressed = true;
            }
            if (_fails == 0)
                _currentImage.sprite = _normalHeart;
            if (_fails == 1)
                _currentImage.sprite = _brokenHeart1;
            if (_fails == 2)
                _currentImage.sprite = _brokenHeart2;
            if (_fails == 3)
                _currentImage.sprite = _brokenHeart3;
        }
    }

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        _currentImage = GetComponent<Image>();
        _warning.GetComponent<Image>().color = new Color(0, 0, 0, 0); //Se desactiva el panel de aviso de primeras
        _beepSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_fails == 3 && !DEBUG) //Se comprueba si se ha llegado a 3 fallos
        {
            GameManager.PlayerStates.SweatCancelMovement();
            GetComponent<HeartMove>().CancelMovement();
            _fails = 0; //Se reestablecen los fallos
        }
    }
}
