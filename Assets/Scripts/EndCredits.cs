using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCredits : MonoBehaviour
{

    #region methods

    public void WaitToEnd()
    {
        SceneManager.LoadScene("StartScene");
    }

    #endregion



    void Start()
    {
        Invoke("WaitToEnd", 55.1f);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            WaitToEnd();
        }
    }
}
