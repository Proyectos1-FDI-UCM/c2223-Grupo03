using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPassValue : MonoBehaviour
{
    #region references
    GameManager gameManager;
    #endregion

    #region properties
    private float _previousValue;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
