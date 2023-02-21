using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeartMove : MonoBehaviour
{
    //El Script se encarga de manejar el movimiento del corazón

    #region parameters

    [SerializeField]
    private float _speed; //Velocidad del corazón

    #endregion

    #region references

    [SerializeField]
    private GameObject _endOfVoid; //Zona final de la barra de fallo
    [SerializeField]
    private GameObject _startOfVoid; //Zona inicial de la barra de fallo

    #endregion

    #region properties



    #endregion

    #region methods

    private void OnTriggerEnter2D(Collider2D collision) //Metodo que se encarga de detectar que se haya chocado con uno de los extremos de la barra de fallo
    {
        if (collision.gameObject == _endOfVoid || collision.gameObject == _startOfVoid) //Si el choque a sido en efecto con dichos componentes
        {
            _speed = _speed * -1; //La velocidad cambia de sentido
            GetComponent<HeartDetection>().ResetValues(); //Se le dice al HeartDetection que reestablezca los valores predeterminaods del corazón
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

        transform.position += new Vector3(1,0,0) * _speed * Time.deltaTime; //Movimiento constante del corazón por medio del transform

    }
}
