using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnComponent : MonoBehaviour
{

    #region References
    private Inventory _inventory;
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private GameObject _keyCheckPoint;
    [SerializeField] private GameObject _player;
    #endregion

    #region Methods
    public void Respawn()
    {
        if (_inventory._llaveEquipado)
        {
            _player.transform.position = _keyCheckPoint.transform.position;
        }
        else
        {
            _player.transform.position = _spawnPoint.transform.position;
        }

    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _inventory = GameManager.Instance.GetComponent<Inventory>();
    }
}
