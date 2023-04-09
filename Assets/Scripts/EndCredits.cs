using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCredits : MonoBehaviour
{
    //Componente para ir de los creditos a la pantalla de start

    #region methods

    //Metodo que carga la pantalla de start
    public void WaitToEnd()
    {
        SceneManager.LoadScene("StartScene");
    }

    #endregion



    void Start()
    {
        Invoke("WaitToEnd", 55.1f);
    }


    //Si se pulsa escape se pasa al start directamente
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            WaitToEnd();
        }
    }
}
