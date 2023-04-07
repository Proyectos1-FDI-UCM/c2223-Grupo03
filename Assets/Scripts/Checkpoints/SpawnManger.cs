using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public static SpawnManger Instance;

    [SerializeField] private bool checkPointActive;
    public bool getCP() { return checkPointActive; }
    public void setCP(bool value) 
    { 
        checkPointActive = value; 
        
    }

    private void Awake()
    {
        if (Instance == null)
        {
            checkPointActive = false;
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
}
