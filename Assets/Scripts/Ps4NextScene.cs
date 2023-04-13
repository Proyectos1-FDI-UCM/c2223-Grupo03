using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ps4NextScene : MonoBehaviour
{
    [SerializeField] int NumeroASaltar;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButton("AspaPs4"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + NumeroASaltar);
        }
    }
}
