using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class ClockDistractionComponent : MonoBehaviour
{
    #region refrences
    private AudioSource _ring;
    #endregion

    #region parameters
    private bool _isIstanced;
    public bool SetInstance { set { _isIstanced = value; } }

    [SerializeField] private int _timesCalled;
    [SerializeField] private float _totalTime;
    [SerializeField] private float _loopTime;
    [SerializeField] private int _currentLoop;

    [SerializeField] private int _raysCasted;
    [SerializeField] private float _raysDistance;
    [SerializeField] private LayerMask _raysMask;
    private float _currentAngle;
    #endregion

    #region methods
    public void CreateDistraction ()
    {
        _currentAngle = 0;
        for (int i = 0; i <= _raysCasted; i++)
        {
            RaycastHit2D raycast = Physics2D.Raycast(this.transform.position, GetVectorFromAngle(_currentAngle), _raysDistance, _raysMask);
            if (raycast.collider != null  && raycast.collider.gameObject.GetComponent<EnemyAI>() != null)
            {
                raycast.collider.gameObject.GetComponent<DistractedComponent>().CreateDistraction(gameObject);
            } 
            _currentAngle += 360 / _raysCasted;
        }
    }

    private Vector3 GetVectorFromAngle(float angle)
    {
        float angRadians = (angle * Mathf.PI) / 180;
        return new Vector3(Mathf.Cos(angRadians), Mathf.Sin(angRadians)).normalized;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _currentLoop = 0;
        _loopTime = _totalTime / _timesCalled;
        _ring = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isIstanced && _currentLoop < _timesCalled)
        {
            if (_loopTime < 0)
            {
                if (_currentLoop < 2)
                {
                    transform.GetChild(_currentLoop).GetComponent<SpriteRenderer>().color -= new Color (0,0,0,255);
                    transform.GetChild(_currentLoop + 1).GetComponent<SpriteRenderer>().color += new Color (0,0,0,255);
                    _currentLoop++;
                    _loopTime = _totalTime / _timesCalled;
                } else
                {
                    CreateDistraction();
                    transform.GetChild(2).GetComponent<SpriteRenderer>().color -= new Color(0,0,0,255);
                    _ring.Play();
                    _currentLoop++;
                    _loopTime = _totalTime / _timesCalled;
                }
            } else
            {
                _loopTime -= Time.deltaTime;
            }
        } else if (_currentLoop >= _timesCalled)
        {
            Destroy(gameObject);
        }
    }
}
