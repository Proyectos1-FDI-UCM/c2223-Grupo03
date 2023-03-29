using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public static SpawnManger Instance;

    private bool checkPointActive;
    public bool getCP { get { return checkPointActive; } }
    public bool setCP { set { checkPointActive = value; } }

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
