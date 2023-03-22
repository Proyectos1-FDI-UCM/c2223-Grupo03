using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialKillComponent : MonoBehaviour
{
    #region References
    [SerializeField] private GameObject _playerInCloset;
    private RespawnComponent _respawnComp;
    #endregion

    #region Methods
    void Start()
    {
        _respawnComp = GameManager.Instance.GetComponent<RespawnComponent>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _respawnComp.Respawn();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    #endregion
}
