using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
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
    
}
