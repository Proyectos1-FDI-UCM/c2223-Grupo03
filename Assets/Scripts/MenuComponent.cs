using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuComponent : MonoBehaviour
{
    #region references

    [SerializeField] private GameObject _pauseFirstButton, _optionFirstButton, _controlerFirstButton, _keyboardFirstButton, _soundFirstButton;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
