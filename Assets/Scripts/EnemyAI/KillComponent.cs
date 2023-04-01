using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillComponent : MonoBehaviour
{
    
    #region References
    [SerializeField] private GameObject _playerInCloset;
    private EnemyAI _enemyAI;
    private RespawnComponent _respawnComp;
    #endregion

    #region Methods
    void Start()
    {
        _enemyAI = GetComponent<EnemyAI>();
        //_respawnComp = GameManager.Instance.GetComponent<RespawnComponent>();
    }

    private void Update()
    {
        if (_enemyAI.Chasing && _playerInCloset.active &&
            Vector2.Distance(transform.position, _playerInCloset.transform.position) < 1f)
        {
            GameManager.Instance.GameOver();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //_respawnComp.Respawn();
            GameManager.Instance.GameOver();
        }
    }
    #endregion
}
