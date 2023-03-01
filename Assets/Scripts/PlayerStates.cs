using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerStates : MonoBehaviour
{
    private bool _hidden;
    public bool Hidden { get { return _hidden; } }

    #region parameters

    [SerializeField] private float _timeOutPill = 10;
    private float _oldSpeed;

    #endregion


    #region properties

    private bool _withEffect = false;
    public bool WithEffect { get { return _withEffect; } }

    #endregion

    #region references
    [SerializeField] private GameObject _warning;
    [SerializeField] private GameObject _heart;
    [SerializeField] private GameObject _safeZone;
    [SerializeField] private GameObject _heartBar;
    #endregion


    #region methods

    public void PillEffect()
    {
        if (!_withEffect)
        {
            _heart.GetComponent<HeartMove>().enabled = false;
            _safeZone.GetComponent<ProximityComponent>().enabled = false;
            _heartBar.SetActive(false);
            Invoke("Flicker", _timeOutPill - 4);
            Invoke("ActiveHeart", _timeOutPill);
            //QUITAR PASTILLA DEL INVENTARIO
            _withEffect = true;
        }
    }

    private void Flicker()
    {
        _heartBar.SetActive(true);
        _heartBar.transform.GetChild(0).GetComponent<ParpadeoComponent>().enabled = true;
        _heartBar.transform.GetChild(1).GetComponent<ParpadeoComponent>().enabled = true;
        _heartBar.transform.GetChild(2).GetComponent<ParpadeoComponent>().enabled = true;

    }

    private void ActiveHeart()
    {
        _heartBar.transform.GetChild(0).GetComponent<ParpadeoComponent>().enabled = false;
        _heartBar.transform.GetChild(0).GetComponent<Image>().color += new Color(0, 0, 0, 0.25f);
        _heartBar.transform.GetChild(1).GetComponent<ParpadeoComponent>().enabled = false;
        _heartBar.transform.GetChild(1).GetComponent<Image>().color += new Color(0, 0, 0, 0.25f);
        _heartBar.transform.GetChild(2).GetComponent<ParpadeoComponent>().enabled = false;
        _heartBar.transform.GetChild(2).GetComponent<Image>().color += new Color(0, 0, 0, 0.25f);
        _heart.GetComponent<HeartMove>().enabled = true;
        _safeZone.GetComponent<ProximityComponent>().enabled = true;
        _withEffect = false;
    }

    public void CancelMovement()
    {
        _oldSpeed = GetComponent<MovementComponent>().speed;
        GetComponent<MovementComponent>().speed = 0;
        Invoke("ActiveMovement", 3);
    }

    private void ActiveMovement()
    {
        GetComponent<MovementComponent>().speed = _oldSpeed;
    }

    #endregion

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
