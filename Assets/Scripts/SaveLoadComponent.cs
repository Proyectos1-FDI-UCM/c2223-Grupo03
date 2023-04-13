using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveLoadComponent : MonoBehaviour
{
    public static SaveLoadComponent Instance;
    private SpawnManger _spawnManger;
    public string _archivoGuardado;
    public DatosJuego _datosJuego = new DatosJuego();
    private int _lvlNumber;


    private void Awake()
    {
        _archivoGuardado = Application.dataPath + "/datosJuego.json";
        /*if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }*/
        
    }
    public void CargarDatos()
    {
        if(File.Exists(_archivoGuardado)) 
        {
            string contenido = File.ReadAllText(_archivoGuardado);
            _datosJuego = JsonUtility.FromJson<DatosJuego>(contenido);
            _lvlNumber = _datosJuego._levelNumber;
            if (_lvlNumber == 18)
            {
                CurrentScene();

                _spawnManger.GetComponent<CheckpointsFinalLvl>()._rojo = _datosJuego._redEnemy;
                _spawnManger.GetComponent<CheckpointsFinalLvl>()._azul = _datosJuego._blueEnemy;
                _spawnManger.GetComponent<CheckpointsFinalLvl>()._verde = _datosJuego._greenEnemy;
                _spawnManger.GetComponent<CheckpointsFinalLvl>()._marron = _datosJuego._brownEnemy;
                Debug.Log("Verde" + _spawnManger.GetComponent<CheckpointsFinalLvl>()._verde);
                Debug.Log("Carga Partida");
            }
            else
            {
                _spawnManger.setCP(_datosJuego._checkpointActive);
                CurrentScene();
                Debug.Log("Carga Partida");
            }
     
        }
        else
        {
            Debug.Log("No hay archivo guardado");
        }
    }

    public void GuardarDatos()
    {
        _lvlNumber = GameObject.Find("Nivel").GetComponent<LevelNumber>()._levelNumber;

        DatosJuego nuevosDatos;

        if (_lvlNumber == 18)
        {
             nuevosDatos = new DatosJuego()
            {
                _checkpointActive = _spawnManger.GetComponent<SpawnManger>().getCP(),
                _levelNumber = _lvlNumber,
                _redEnemy = _spawnManger.GetComponent<CheckpointsFinalLvl>()._rojo,
                _blueEnemy = _spawnManger.GetComponent<CheckpointsFinalLvl>()._azul,
                _greenEnemy = _spawnManger.GetComponent<CheckpointsFinalLvl>()._verde,
                _brownEnemy = _spawnManger.GetComponent<CheckpointsFinalLvl>()._marron,


            };

        }
        else
        {
            nuevosDatos = new DatosJuego()
            {
                _checkpointActive = _spawnManger.GetComponent<SpawnManger>().getCP(),
                _levelNumber = _lvlNumber,
               
            };

        }


        string cadenaJSON = JsonUtility.ToJson(nuevosDatos);

        File.WriteAllText(_archivoGuardado, cadenaJSON);

        Debug.Log("Archivo guardado");

    }

    private void CurrentScene()
    {
        SceneManager.LoadScene(_lvlNumber);
    }

    private void Start()
    {
        _spawnManger = GameObject.Find("SpawnManager").GetComponent<SpawnManger>();
       
        
    }
}
