using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    #region References
    [SerializeField] private bool _chasing;
    [SerializeField] private Rigidbody2D _player;
    [SerializeField] private GameObject _cone;

    [Header("Parámetros pathing")]
    [SerializeField] private GameObject _path;
    [SerializeField] private float _speed;
    [SerializeField] private bool _cicle;

    #endregion

    #region Variables
    [SerializeField] private Transform[] _points;
    private NavMeshAgent _navMeshAgent;
    private Rigidbody2D _enemyRigidbody;
    
    private bool forward;
    private int i;
    private Vector2 direction;
    #endregion

    // Funcion auxiliar, guarda en una array puntos de un camino
    private void SetPointsFromPath() 
    {
        int pointNum = _path.transform.childCount;
        _points = new Transform[pointNum];
        int i = 0;
        foreach (Transform child in _path.transform)
        {
            _points[i] = child;
            i++;
        }
    }
    
    void Start()
    {
        i = 0;
        forward = true;
        SetPointsFromPath();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _enemyRigidbody = GetComponent<Rigidbody2D>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }

    private void Update()
    {
        
        _cone.transform.position = _enemyRigidbody.position + direction.normalized * 5;
    }
    void FixedUpdate()
    {
        if (_chasing) //Follow player
        {
            _navMeshAgent.SetDestination(_player.position);
            direction = _player.position - _enemyRigidbody.position;
        }
        else // Follow points
        {
            if (_cicle) // en ciclo
            {
                if (i < _points.Length)
                {
                    if (Vector2.Distance(_enemyRigidbody.position, _points[i].position) > 0.1f)
                    {
                        _navMeshAgent.SetDestination(_points[i].position);
                        direction = (Vector2)_points[i].position - _enemyRigidbody.position;
                    }
                    else
                        i = (i + 1) % _points.Length;
                }
            }
            else // volviendo por sus pasos
            {
                if (i < _points.Length && forward)
                {
                    if (Vector2.Distance(_enemyRigidbody.position, _points[i].position) > 0.1f)
                    {
                        _navMeshAgent.SetDestination(_points[i].position);
                        direction = (Vector2)_points[i].position - _enemyRigidbody.position;
                    }
                    else
                        i++;
                }
                else if (i > 0 && !forward)
                {
                    if (Vector2.Distance(_enemyRigidbody.position, _points[i].position) > 0.1f)
                    {
                        _navMeshAgent.SetDestination(_points[i].position);
                        direction = (Vector2)_points[i].position - _enemyRigidbody.position;
                    }
                    else
                        i--;
                }
                else
                {
                    forward = !forward;
                    if (!forward)
                        i--;
                }
            }
        }
    }
}
