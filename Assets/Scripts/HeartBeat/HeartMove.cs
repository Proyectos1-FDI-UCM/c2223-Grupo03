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
    private float _tempSpeed;
    #endregion

    #region references

    [SerializeField]
    private GameObject _endOfVoid; //Zona final de la barra de fallo
    [SerializeField]
    private GameObject _startOfVoid; //Zona inicial de la barra de fallo
    //zona de parada para tutorial (desaparece tras ser usada)
    [SerializeField] private GameObject _tutorialPoint;
    private bool _waiting;

    private Rigidbody2D _rigidbody;
    #endregion

    #region properties



    #endregion

    #region methods

    private void OnTriggerEnter2D(Collider2D collision) //Metodo que se encarga de detectar que se haya chocado con uno de los extremos de la barra de fallo
    {
        if (collision.gameObject == _endOfVoid || collision.gameObject == _startOfVoid) //Si el choque a sido en efecto con dichos componentes
        {
            _speed = _speed * -1; //La velocidad cambia de sentido
            //Se le dice al HeartDetection que reestablezca los valores predeterminaods del corazón
            GetComponent<HeartDetection>().ResetValues(); 
        }
        else if (collision.gameObject == _tutorialPoint)
        {
            CancelMovementTutorial();
            _waiting = true;
            GameObject.Find("Canvas").GetComponent<TutorialEvents>().Triggered();
            Destroy(_tutorialPoint);
        }
    }

    public void CancelMovementTutorial()
    {
        _tempSpeed = _speed;
        _speed = 0;
    }
    public void CancelMovement()
    {
        _tempSpeed = _speed;
        _speed = 0;
        Invoke("ActiveMovement", 3);
    }
    public void ActiveMovement()
    {
        _speed = _tempSpeed;
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _waiting = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.position += new Vector2(1,0) * _speed * Time.deltaTime; //Movimiento constante del corazón por medio del transform
        if (_waiting && (Input.GetKey(KeyCode.Space) || Input.GetButton("R1Ps4")))
        {
            ActiveMovement();
            _waiting = false;
            GameObject.Find("Canvas").GetComponent<TutorialEvents>().Triggered();
        }
    }
}
