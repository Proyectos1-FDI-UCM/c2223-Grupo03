using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    #region references

    [SerializeField]
    private GameObject _heartBeat;

    #endregion

    #region properties

    private bool _activeFlicker = false;
    private GameObject _flickerObject;


    #endregion


    #region methods

    public void FlickerEffect(GameObject flickerObject)
    {
        _flickerObject = flickerObject;
        _activeFlicker = true;
        
    }

    #endregion


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_activeFlicker)
        {
            GameManager.Instance.GetComponent<ParpadeoComponent>().StartFlicker(_flickerObject, 0.2f);
        }
        
    }
}
