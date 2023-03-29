using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    [SerializeField] private TutorialEvents _tutorialEvents;
    bool used;
    private void Start()
    {
        used = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!used)
        {
            used = true;
            _tutorialEvents.Triggered();
            Destroy(gameObject);
        }
    }
}
