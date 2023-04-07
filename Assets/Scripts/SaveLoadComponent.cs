using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveLoadComponent : MonoBehaviour
{
    private SpawnManger _spawnManger;
    public string _archivoGuardado;
    public DatosJuego _datosJuego = new DatosJuego();


    private void Awake()
    {
        _archivoGuardado = Application.dataPath + "/datosJuego.json";

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)) 
        {
            CargarDatos();
        }
        if(Input.GetKeyDown(KeyCode.G))
        {
            GuardarDatos();
        }
    }
    private void CargarDatos()
    {
        if(File.Exists(_archivoGuardado)) 
        {
            string contenido = File.ReadAllText(_archivoGuardado);
            _datosJuego = JsonUtility.FromJson<DatosJuego>(contenido);
            _spawnManger.setCP(_datosJuego._checkpointActive);
            CurrentScene();
            Debug.Log("Carga Partida");
        }
        else
        {
            Debug.Log("No hay archivo guardado");
        }
    }

    private void GuardarDatos()
    {
        DatosJuego nuevosDatos = new DatosJuego()
        {
            _checkpointActive =_spawnManger.GetComponent<SpawnManger>().getCP(),
            _levelNumber = GameObject.Find("Nivel").GetComponent<LevelNumber>()._levelNumber

        };

        string cadenaJSON = JsonUtility.ToJson(nuevosDatos);

        File.WriteAllText(_archivoGuardado, cadenaJSON);

        Debug.Log("Archivo guardado");

    }

    private void CurrentScene()
    {
        SceneManager.LoadScene(_datosJuego._levelNumber);
    }

    private void Start()
    {
        _spawnManger = GameObject.Find("SpawnManager").GetComponent<SpawnManger>();
    }
}
