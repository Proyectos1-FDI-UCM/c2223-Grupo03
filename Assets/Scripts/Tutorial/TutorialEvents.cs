using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEvents : MonoBehaviour
{
    private int numOfEvent;
    [SerializeField] private GameObject _corazonRoto;

    private PlayerStates _playerStates;
    private HeartDetection _heartDetection;
    private HeartMove _heartMove;
    public void Triggered()
    {
        numOfEvent++;
        ChangeEvent();
    }
    private void ChangeEvent()
    {
        if (numOfEvent == 1)
        {
            HeartBeatEventStart();
        }
        else if (numOfEvent == 2)
        {

        }
        else if (numOfEvent == 3)
        {

        }
    }
    private void HeartBeatEventStart()
    {
        _playerStates.CancelMovement();
        Instantiate(_corazonRoto, transform);
        Invoke("HeartBeatEventStop", 5);
    }
    private void HeartBeatEventStop()
    {
        _heartMove.ActiveMovement();
    }
    void Start()
    {
        numOfEvent = 0;
        _playerStates = GameManager.Player.GetComponent<PlayerStates>();
        _heartDetection = GameObject.Find("Heart").GetComponent<HeartDetection>();
        _heartMove = GameObject.Find("Heart").GetComponent<HeartMove>();
        _heartMove.CancelMovementTutorial();
    }
}
