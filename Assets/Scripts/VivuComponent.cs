using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VivuComponent : MonoBehaviour
{
    [SerializeField] GameObject telon;
    private GameObject palancas;
    private CheckpointsFinalLvl checkpointsFinal;
    private void Start()
    {
        checkpointsFinal = GameObject.Find("SpawnManager").GetComponent<CheckpointsFinalLvl>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        palancas = GameObject.Find("Palancas");
        int num = 0;
        for (int i = 0; i < palancas.transform.childCount; i++)
        {
            if (palancas.transform.GetChild(i).gameObject.active)
                num++;
        }
        if (collision.gameObject.tag == "Player" && num == 0)
        {
            checkpointsFinal.DesactivarTodo();
            GameObject canvas = GameObject.Find("Canvas");
            Instantiate(telon, canvas.transform);
            Invoke("Creditos", 1.5f);
        }
    }
    private void Creditos()
    {
        SceneManager.LoadScene("Final Transition");
    }
}
