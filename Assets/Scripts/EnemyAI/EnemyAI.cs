using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    #region References
    [SerializeField] private Rigidbody2D _player;
    [SerializeField] private GameObject _path;
    #endregion

    #region Variables
    private NavMeshAgent _navMeshAgent;
    #endregion
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }

    void FixedUpdate()
    {
        
    }
}
