using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsFinalLvl : MonoBehaviour
{
    public static CheckpointsFinalLvl Instance;
 

    private GameObject _palancas;
    private GameObject _palancaRojo;
    private GameObject _palancaVerde;
    private GameObject _palancaAzul;
    private GameObject _palancaMarron;

    private GameObject _enemigos;
    private GameObject _enemigoVerde;
    private GameObject _enemigoAzul;
    private GameObject _enemigoRojo;
    private GameObject _enemigoMarron;

    public bool _rojo, _verde, _azul, _marron;

    private void CheckpointFinalLvl()
    {

        _palancas = GameObject.Find("Palancas");
        _palancaRojo = _palancas.transform.GetChild(0).gameObject;
        _palancaMarron = _palancas.transform.GetChild(1).gameObject;
        _palancaAzul = _palancas.transform.GetChild(2).gameObject;
        _palancaVerde = _palancas.transform.GetChild(3).gameObject;

        _enemigos = GameObject.Find("Enemigos");
        _enemigoRojo = _enemigos.transform.GetChild(3).gameObject;
        _enemigoMarron = _enemigos.transform.GetChild(0).gameObject;
        _enemigoAzul = _enemigos.transform.GetChild(1).gameObject;
        _enemigoVerde = _enemigos.transform.GetChild(2).gameObject;

      
        if (_rojo)
        {
            _enemigoRojo.SetActive(false);
            Destroy(_palancaRojo);
        }
        if(_verde)
        {
            _enemigoVerde.SetActive(false);
            Destroy(_palancaVerde);
        }
        if(_azul)
        {
            _enemigoAzul.SetActive(false);
            Destroy(_palancaAzul);
        }
        if(_marron)
        {
            _enemigoMarron.SetActive(false);
            Destroy(_palancaMarron);
        }

   
    }

    // Update is called once per frame
    void Update()
    {
        PalancaActive();
        
    }

    private void Awake()
    {
        if (Instance == null)
        {
            CheckpointFinalLvl();
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Instance.CheckpointFinalLvl();
            Destroy(gameObject);

        }
    }

    private void PalancaActive()
    {
        if (!_rojo && _palancaRojo.GetComponent<PalancaComponent>()._palancaActive)
        {
            _rojo = true;
        }
        if (!_verde && _palancaVerde.GetComponent<PalancaComponent>()._palancaActive)
        {
            _verde = true;
        }
        if (!_azul && _palancaAzul.GetComponent<PalancaComponent>()._palancaActive)
        {
            _azul = true;
        }
        if (!_marron && _palancaMarron.GetComponent<PalancaComponent>()._palancaActive)
        {
            _marron = true;
        }
    }

    }
