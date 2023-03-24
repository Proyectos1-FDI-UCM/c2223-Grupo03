using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseInput : MonoBehaviour
{
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) && (GameManager.Instance.ActualMenu == GameManager.Menus.NoMenu || GameManager.Instance.ActualMenu == GameManager.Menus.PAUSE))
        {
            GameManager.Instance.ChangePause();
        }
    }
}
