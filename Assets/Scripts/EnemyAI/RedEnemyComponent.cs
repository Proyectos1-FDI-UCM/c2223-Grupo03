using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemyComponent : MonoBehaviour
{
    #region references
    private EnemyAI _myEnemyAI;
    #endregion

    #region properties
    private enum WardroveStates { Look, Search, Ignore }
    private float _time;
    [SerializeField] private WardroveStates _current;

    [SerializeField] private float _wardroveTime;
    [SerializeField] private float _ignoreTime;
    #endregion

    #region methods
    /// <summary>
    /// Función que cambia de estado y resetea el tiempo de estados
    /// </summary>
    private void ChangeLooking()
    {
        if (_current == WardroveStates.Look)
        {
            _current = WardroveStates.Search;
            _time = _wardroveTime;
            _myEnemyAI.Moving = false;
            _myEnemyAI.SetDestination(EnemyAI.EnemyType.Red);
        }
        else if (_current == WardroveStates.Search)
        {
            _current = WardroveStates.Ignore;
            _time = _ignoreTime;
            _myEnemyAI.Moving = true;
        }
        else if (_current == WardroveStates.Ignore)
        {
            _current = WardroveStates.Look;
            _time = 10;
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _time = _ignoreTime;
        _current = WardroveStates.Ignore;
        _myEnemyAI = GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_myEnemyAI.Chasing == false)
        {
            if (_current == WardroveStates.Look)
            {
                if (_myEnemyAI.GetCloset != null)
                {
                    ChangeLooking();
                    _myEnemyAI.LookAtObject(_myEnemyAI.GetCloset);
                }
            } else if (_current == WardroveStates.Search)
            {
                _myEnemyAI.LookAtObject(_myEnemyAI.GetCloset);
                _time -= Time.deltaTime;
            } else
            {
                _time -= Time.deltaTime;
            }
        }
        else if (_current != WardroveStates.Ignore)
        {
            _current = WardroveStates.Ignore;
            _myEnemyAI.Moving = true;
        }
        if (_time < 0)
        {
            ChangeLooking();
        }
    }
}
