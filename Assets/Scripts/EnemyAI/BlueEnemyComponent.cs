using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemyComponent : MonoBehaviour
{
    #region references
    private EnemyAI _myEnemyAI;
    #endregion

    #region properties
    private enum LookingStates { Forward, Searching, Backwards }
    private float _time;
    private LookingStates _current;

    [SerializeField] private float _walkingTime;
    [SerializeField] private float _searchingTime;
    [SerializeField] private float _backwardsTime;
    #endregion

    #region methods
    private void ChangeLooking()
    {
        if (_current == LookingStates.Forward)
        {
            _current = LookingStates.Searching;
            _time = _searchingTime;
            _myEnemyAI.Moving = false;
            _myEnemyAI.StopDestination(EnemyAI.EnemyType.Blue);
        } else if (_current == LookingStates.Searching)
        {
            _current = LookingStates.Backwards;
            _time = _backwardsTime;
            _myEnemyAI.InvertDirection();
        } else if (_current == LookingStates.Backwards)
        {
            _current = LookingStates.Forward;
            _time = _walkingTime;
            _myEnemyAI.Moving = true;
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myEnemyAI = GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_myEnemyAI.Chasing == false)
        {
            _time -= Time.deltaTime;
        } else if (_current != LookingStates.Forward)
        {
            _current = LookingStates.Forward;
            _myEnemyAI.Moving = true;
        }
        if (_time < 0 )
        {
            ChangeLooking();
        }
    }
}
