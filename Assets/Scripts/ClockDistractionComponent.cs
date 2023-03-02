using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class ClockDistractionComponent : MonoBehaviour
{
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
            RaycastHit2D raycast = Physics2D.Raycast(this.transform.position, GetVectorFromAngle(_currentAngle), _raysDistance);

            if (raycast.collider != null && raycast.collider.gameObject.GetComponent<EnemyAI>() != null)
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
    }

    // Update is called once per frame
    void Update()
    {
        if (_isIstanced && _currentLoop < _timesCalled)
        {
            if (_loopTime < 0)
            {
                _currentLoop++;
                _loopTime = _totalTime / _timesCalled;
                CreateDistraction();
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
