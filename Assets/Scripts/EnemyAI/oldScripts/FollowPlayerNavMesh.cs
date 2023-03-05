using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayerNavMesh : MonoBehaviour
{
    [SerializeField] Rigidbody2D _player;
    private NavMeshAgent _navMeshAgent;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }

    void FixedUpdate()
    {
        _navMeshAgent.SetDestination(_player.position);
    }
}
