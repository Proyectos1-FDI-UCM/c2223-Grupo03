using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPassValue : MonoBehaviour
{
    #region references
    GameManager gameManager;
    Slider _mySlide;
    #endregion

    #region properties
    private float _previousValue;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        _mySlide = GetComponent<Slider>();
        if (_mySlide!= null )
        {
            Debug.Log("is?");
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        if (_mySlide.value != _previousValue)
        {
            Debug.Log("waluigi");
            _previousValue = _mySlide.value;
            gameManager.changeSound(gameObject.name, _previousValue);
        }
    }
}