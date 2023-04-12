using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class StormManager : MonoBehaviour
{
    #region parameters
    float cont = 0;
    float rdnNum = 5;
    #endregion
    #region properties
    AudioSource _audioSource;
    #endregion
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        //desactiva todas las luces hijas del gameObject
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    void Update()
    {
        cont += Time.deltaTime;
        if (cont > rdnNum)
        {
            _audioSource.Play();
            cont = 0;
            rdnNum = GeneraRadom();
        }
        else if (cont > rdnNum - 0.4)
        {
            ActivarHijos(false);
        }
        else if (cont > rdnNum - 0.6)
        {
            ActivarHijos(true);
        }
        else if (cont > rdnNum - 0.7)
        {
            ActivarHijos(false);
        }
        else if (cont > rdnNum - 0.8)
        {
            ActivarHijos(true);
        }
        else if (cont > rdnNum - 1)
        {
            ActivarHijos(false);
        }
    }

    static int GeneraRadom()
    {
        int num = Random.Range(10, 25);
        return num;
    }

    void ActivarHijos(bool activar)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(activar);
        }
    }
}
