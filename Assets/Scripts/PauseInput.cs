using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseInput : MonoBehaviour
{





    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && (GameManager.Instance.ActualMenu == GameManager.Menus.NoMenu || GameManager.Instance.ActualMenu == GameManager.Menus.PAUSE))
        {
            GameManager.Instance.ChangePause();
        }
    }
}
