using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNumber : MonoBehaviour
{
    
    [SerializeField] public int _levelNumber;
    private GameObject _checkpointFinal;

    private void Start()
    {
        _checkpointFinal = GameObject.Find("SpawnManager");
        if(_levelNumber == 18)
        {
            _checkpointFinal.GetComponent<CheckpointsFinalLvl>().CheckpointFinalLvl();
        }
    }

}
