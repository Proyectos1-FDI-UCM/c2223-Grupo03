using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private int _id;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(_id);
    }
}
