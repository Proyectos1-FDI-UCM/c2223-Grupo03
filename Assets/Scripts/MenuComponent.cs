using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuComponent : MonoBehaviour
{
    //Metodo para cambiar el primer boton segun el menu al que se llegue para permitir la navegabilidad entre menus

    #region references

    [SerializeField] private GameObject _pauseFirstButton, _optionFirstButton, _controlerFirstButton, _keyboardFirstButton, _soundFirstButton;
    private GameObject _lastSelectedButton;


    #endregion


    #region methods

    public void ChangeMenu(GameManager.Menus newMenu)
    {
        EventSystem.current.SetSelectedGameObject(null);

        if (newMenu == GameManager.Menus.PAUSE)
        {
            EventSystem.current.SetSelectedGameObject(_pauseFirstButton);
        }
        else if (newMenu == GameManager.Menus.OPTIONS)
        {
            EventSystem.current.SetSelectedGameObject(_optionFirstButton);
        }
        else if (newMenu == GameManager.Menus.CONTROLS)
        {
            EventSystem.current.SetSelectedGameObject(_controlerFirstButton);
        }
        else if (newMenu == GameManager.Menus.TECLADO)
        {
            EventSystem.current.SetSelectedGameObject(_keyboardFirstButton);
        }
        else if (newMenu == GameManager.Menus.SOUND)
        {
            EventSystem.current.SetSelectedGameObject(_soundFirstButton);
        }
    }

    #endregion
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null) // revisamos el problema del mando de ps4 que no halla deseleccionado el boton en pc
        {
            EventSystem.current.SetSelectedGameObject(_lastSelectedButton);
        }
        _lastSelectedButton = EventSystem.current.currentSelectedGameObject;
    }
}
