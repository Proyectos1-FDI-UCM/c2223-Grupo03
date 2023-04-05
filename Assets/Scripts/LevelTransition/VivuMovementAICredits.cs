using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VivuMovementAICredits : MonoBehaviour
{
    public float speed;

    private Rigidbody2D _playerRigidbody;
    private Vector2 movement;
    private Animator _animator;
    private void Start()
    {
        _playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    void Update()
    {

    }
    private void FixedUpdate()
    {
        _playerRigidbody.velocity = new Vector2(speed, 0);
        _animator.SetFloat("Vivu_LeftWalk", -1);
    }
}
