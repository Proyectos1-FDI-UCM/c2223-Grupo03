using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    private GameObject _lastSelectedButton;

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
    public void LevelSelector()
    {
        SceneManager.LoadScene(1);

    }
    public void CurrentSceneMove(int i)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + i);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        GameManager.Instance.ChangePause();
    }
    public void LoadLevel(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }

    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null) // revisamos el problema del mando de ps4 que no halla deseleccionado el boton en pc
        {
            EventSystem.current.SetSelectedGameObject(_lastSelectedButton);
        }
        _lastSelectedButton = EventSystem.current.currentSelectedGameObject;
    }

}
