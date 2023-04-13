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
    [SerializeField] GameObject _tecladoControlsMenu;
    #endregion

    #region properties


    #endregion

    #region methods

    //Método para activar y deactivar el menu de pausa
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

    //Metodo para cambiar a un menu concreto activandolo y desactivando todos los menus que pudiera haber antes
    public void ChangeMenu(GameManager.Menus newMenu)
    {
        if (newMenu == GameManager.Menus.OPTIONS)
        {
            _pauseMenu.SetActive(false);
            _controlsMenu.SetActive(false);
            _soundMenu.SetActive(false);
            _tecladoControlsMenu.SetActive(false);
            _optionsMenu.SetActive(true);
        }
        else if (newMenu == GameManager.Menus.CONTROLS)
        {
            _optionsMenu.SetActive(false);
            _tecladoControlsMenu.SetActive(false);
            _controlsMenu.SetActive(true);
        }
        else if (newMenu == GameManager.Menus.SOUND)
        {
            _optionsMenu.SetActive(false);
            _soundMenu.SetActive(true);
        }
        else if (newMenu == GameManager.Menus.PAUSE)
        {
            _optionsMenu.SetActive(false);
            _pauseMenu.SetActive(true);
        }
        else if (newMenu == GameManager.Menus.TECLADO)
        {
            _controlsMenu.SetActive(false);
            _tecladoControlsMenu.SetActive(true);
        }
    }

    //Pide al GameManager que cambie el menu por otro dado un número
    public void RequestMenuChange(int i)
    {
        GameManager.Instance.RequestMenuChange((GameManager.Menus)i);
    }

    public void OutOfOptions()
    {
        _optionsMenu.SetActive(false);
    }

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        _pauseMenu.SetActive(false);
        _controlsMenu.SetActive(false);
        _optionsMenu.SetActive(false);
        _soundMenu.SetActive(false);
        _tecladoControlsMenu.SetActive(false);
        _controlsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
