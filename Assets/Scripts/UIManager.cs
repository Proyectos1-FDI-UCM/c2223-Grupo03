using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    #region references
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] GameObject _musicSlider;
    [SerializeField] GameObject _SFXslider;
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
