using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTieso : MonoBehaviour
{
    [SerializeField] GameObject originalPoint;
    [SerializeField] GameObject lookAt;
    private EnemyAI enemyAI;
    private void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, originalPoint.transform.position) < 0.3f)
        {
            enemyAI.LookAtObject(lookAt);
        }
    }
}
