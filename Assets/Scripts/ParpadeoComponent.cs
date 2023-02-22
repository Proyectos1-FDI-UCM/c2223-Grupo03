using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParpadeoComponent : MonoBehaviour
{
    #region parameters

    [SerializeField]
    private float _flickerSpeed;

    #endregion


    #region properties

    private float _elapsedTime;
    private bool _oneColor;


    #endregion

    #region methods

    public void StartFlicker (GameObject flickerObject, float flickerSpeed)
    {
        _flickerSpeed = flickerSpeed;

        if (_oneColor)
        {
            flickerObject.SetActive(false);
        }
        else
        {
            flickerObject.SetActive(true);
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
        if (_elapsedTime >= _flickerSpeed)
        {
            if (_oneColor)
            {
                _oneColor = false;


            }
            else
            {
                _oneColor = true;
            }
            Debug.Log("aa");
            _elapsedTime = 0;
        }
        else
        {
            _elapsedTime += Time.deltaTime;
        }



    }
}
