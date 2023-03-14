using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEvents : MonoBehaviour
{
    private int numOfEvent;
    [SerializeField] private GameObject _corazonRoto;

    private PlayerStates _playerStates;
    public void Triggered()
    {
        numOfEvent++;
        ChangeEvent();
    }
    private void ChangeEvent()
    {
        if (numOfEvent == 1)
        {
            HeartBeatStart();
        }
        else if (numOfEvent == 2)
        {

        }
        else if (numOfEvent == 3)
        {

        }
    }
    private void HeartBeatStart()
    {
        _playerStates.CancelMovement();
        Instantiate(_corazonRoto, transform);
    }
    void Start()
    {
        numOfEvent = 0;
        _playerStates = GameManager.Player.GetComponent<PlayerStates>();
    }
}
