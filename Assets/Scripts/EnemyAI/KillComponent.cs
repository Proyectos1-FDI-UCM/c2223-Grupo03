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
        /*if (_enemyAI.Chasing && _playerInCloset.active &&
            Vector2.Distance(transform.position, _playerInCloset.transform.position) < 1f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }*/
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //_respawnComp.Respawn();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    #endregion
}
