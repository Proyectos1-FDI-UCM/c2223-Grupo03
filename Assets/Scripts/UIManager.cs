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



    #region methods

    public void PillEffect()
    {
        _heartBeat.transform.GetChild(3).gameObject.GetComponent<Image>().color = new Color(0, 1, 0, 0.25f);
        _heartBeat.transform.GetChild(3).gameObject.SetActive(true);
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
