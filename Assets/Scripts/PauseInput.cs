using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseInput : MonoBehaviour
{
    private float _time;
    //Input propio para la pausa, que no se desactiva al pausar el juego
    void Update()
    {
        if ((Keyboard.current[Key.P].wasPressedThisFrame || Keyboard.current[Key.Escape].wasPressedThisFrame || Gamepad.current.startButton.wasPressedThisFrame) && (GameManager.Instance.ActualMenu == GameManager.Menus.NoMenu || GameManager.Instance.ActualMenu == GameManager.Menus.PAUSE) && _time > 0.5)
        {
            _time = 0;
            GameManager.Instance.ChangePause();
        }
        _time += Time.deltaTime;
    }
}
