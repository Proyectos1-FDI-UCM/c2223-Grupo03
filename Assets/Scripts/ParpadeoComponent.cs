using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ParpadeoComponent : MonoBehaviour
{
    //Componente que sirve para atribuir a objetos o a la UI un efecto de parpadeo al cambiar su transparencia

    #region parameters

    [SerializeField]
    private float _flickerSpeed; //Velocidad a la que van los parpadeos

    #endregion


    #region properties

    private float _elapsedTime; //Tiempo que ha pasado
    private bool _oneColor; //Booleano que sirve para alternar entre la transparencia y la opacidad


    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.GetComponent<SpriteRenderer>() != null) //Se comprueba que es un GameObject y no una parte de la UI
        {
            if (_elapsedTime >= _flickerSpeed) //Si el tiempo transcurrido es mayor a la velocidad de parpadeo
            {
                if (_oneColor) //Si esta en estado transparente
                {
                    _oneColor = false; //El estado cambia a opaco
                    gameObject.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.25f); //Se aumenta la transparencia

                }
                else //Si esta en estado opaco
                {
                    _oneColor = true; //El estado cambia a transparente
                    gameObject.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.25f); //Se reduce la transparencia
                }
                _elapsedTime = 0; //Al final el tiempo transcurrido se vuelve a poner a 0
            }
            else
            {
                _elapsedTime += Time.deltaTime; 
            }
        }
        else if (gameObject.GetComponent<Image>() != null) //Se comprueba que es un UI y no un GameObject. Por lo demás se hace igual
        {
            if (_elapsedTime >= _flickerSpeed)
            {
                if (_oneColor)
                {
                    _oneColor = false;
                    gameObject.GetComponent<Image>().color += new Color(0, 0, 0, 0.25f);

                }
                else
                {
                    _oneColor = true;
                    gameObject.GetComponent<Image>().color -= new Color(0, 0, 0, 0.25f);
                }
                _elapsedTime = 0;
            }
            else
            {
                _elapsedTime += Time.deltaTime;
            }
        }
        else
        {
            if (_elapsedTime >= _flickerSpeed)
            {
                if (_oneColor)
                {
                    _oneColor = false;
                    gameObject.SetActive(false);

                }
                else
                {
                    _oneColor = true;
                    gameObject.SetActive(true);
                }
                _elapsedTime = 0;
            }
            else
            {
                _elapsedTime += Time.deltaTime;
            }
        }
        



    }
}
