using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class FollowPoints : MonoBehaviour
{
    [SerializeField] private GameObject _path;
    private Transform[] _points;
    [SerializeField] private bool _cicle;
    private Rigidbody2D _enemyRigidbody;
    private NavMeshAgent _navMeshAgent;
    private int i;
    private bool forward;

    private void SetPointsFromPath()
    {
        int pointNum = _path.transform.childCount;
        _points = new Transform[pointNum];
        i = 0;
        foreach (Transform child in _path.transform)
        {
            _points[i] = child;
            i++;
        }
    }
    void FixedUpdate()
    {
        if (_cicle)
        {
            if (i < _points.Length)
            {
                if (Vector2.Distance(_enemyRigidbody.position, _points[i].position) > 0.3f)
                {
                    _navMeshAgent.SetDestination(_points[i].position);
                }
                else
                    i = (i + 1) % _points.Length;
            }
        }
        else
        {
            if (i < _points.Length && forward)
            {
                if (Vector2.Distance(_enemyRigidbody.position, _points[i].position) > 0.3f)
                {
                    _navMeshAgent.SetDestination(_points[i].position);
                }
                else
                    i++;
            }
            else if (i > 0 && !forward)
            {
                if (Vector2.Distance(_enemyRigidbody.position, _points[i].position) > 0.3f)
                {
                    _navMeshAgent.SetDestination(_points[i].position);
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
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
        _enemyRigidbody = GetComponent<Rigidbody2D>();
        forward = true;
        SetPointsFromPath();
    }
}
