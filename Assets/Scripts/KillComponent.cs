using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillComponent : MonoBehaviour
{

    #region References
    private RespawnComponent _respawnComp;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _respawnComp = GameManager.Instance.GetComponent<RespawnComponent>();
    }


    #region Methods

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
