using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class DistractedComponent : MonoBehaviour
{
    #region references
    private EnemyAI _myEnemyAI;
    private Rigidbody2D _myRigidbody2D;
    #endregion

    #region parameters
    public enum Distract { NotDistracted, MovingTowards, OnDistraction}
    private Distract _current;
    public Distract GetDistraught { get { return _current; } }

    private float _time;
    [SerializeField] private float _distractTime;

    private Vector3 _distractPosition;
    private float _currentDistance;
    private float _newDistance;
    [SerializeField] private float _arrivalDistance;
    #endregion

    #region methods
    private void ChangeDistraction (Distract current)
    {
        if (current == Distract.NotDistracted)
        {
            _myEnemyAI.Moving = false;
            _current = Distract.MovingTowards;
            _myEnemyAI.SetDestination(_distractPosition);
            _time = 1;
        } else if (current == Distract.MovingTowards)
        {
            _current = Distract.OnDistraction;
            _time = _distractTime;
        } else if (current == Distract.OnDistraction)
        {
            _current = Distract.NotDistracted;
            _myEnemyAI.Moving = true;
            _time = 1;
        }
    }

    public void CreateDistraction(GameObject distraction)
    {
        _newDistance = (_myRigidbody2D.position - (Vector2)distraction.transform.position).magnitude;
        if (_currentDistance > _newDistance || _current == Distract.NotDistracted)
        {
            _distractPosition = distraction.transform.position;
            ChangeDistraction(Distract.NotDistracted);
            _myEnemyAI.LookAtObject(distraction);
        }     
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myEnemyAI = GetComponent<EnemyAI>();
        _myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_myEnemyAI.Chasing)
        {
            if (_current == Distract.OnDistraction)
            {
                _time -= Time.deltaTime;
            } 
            if (_time < 0 || (_current == Distract.MovingTowards && _currentDistance <= _arrivalDistance))
            {
                ChangeDistraction(_current);
            }
        } else
        {
            _current = Distract.NotDistracted;
            _myEnemyAI.Moving = true;
        }
    }
}
