using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
//using System.Diagnostics;

public class UIManager : MonoBehaviour
{

    #region references

    [SerializeField] GameObject _pauseMenu;
    [SerializeField] GameObject _optionsMenu;
    [SerializeField] GameObject _controlsMenu;
    [SerializeField] GameObject _soundMenu;
    #endregion

    #region properties


    #endregion


    #region methods

    public void PauseMenu()
    {
        if (!GameManager.Instance.IsPause)
        {
            _pauseMenu.SetActive(true);
        }
        else
        {
            _pauseMenu.SetActive(false);
        }
    }

    public void ChangeMenu(GameManager.Menus newMenu)
    {
        if (newMenu == GameManager.Menus.OPTIONS)
        {
            Debug.Log("Llego 4");
            _pauseMenu.SetActive(false);
            _optionsMenu.SetActive(true);
        }
        else if (newMenu == GameManager.Menus.CONTROLS)
        {
            _optionsMenu.SetActive(false);
            _controlsMenu.SetActive(true);
        }
        else if (newMenu == GameManager.Menus.SOUND)
        {
            _optionsMenu.SetActive(false);
            _soundMenu.SetActive(true);
        }
    }

    public void RequestMenuChange(int i)
    {
        GameManager.Instance.RequestMenuChange((GameManager.Menus)i);
        Debug.Log("Llego1");
    }

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        _pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
