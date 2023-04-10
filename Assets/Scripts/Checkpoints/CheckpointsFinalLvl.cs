using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsFinalLvl : MonoBehaviour
{
    public static CheckpointsFinalLvl Instance;
    [SerializeField] private GameObject _palancaRojo;
    [SerializeField] private GameObject _palancaVerde;
    [SerializeField] private GameObject _palancaAzul;
    [SerializeField] private GameObject _palancaMarron;

    [SerializeField] private GameObject _enemigoRojo;
    [SerializeField] private GameObject _enemigoVerde;
    [SerializeField] private GameObject _enemigoAzul;
    [SerializeField] private GameObject _enemigoMarron;

    public bool _rojo, _verde, _azul, _marron;

    // Start is called before the first frame update
    void Start()
    {
        if(_rojo)
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
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
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
