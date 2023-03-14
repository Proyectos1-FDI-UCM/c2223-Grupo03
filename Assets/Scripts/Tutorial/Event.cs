using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    [SerializeField] private TutorialEvents _tutorialEvents;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _tutorialEvents.Triggered();
        Destroy(gameObject);
    }
}
