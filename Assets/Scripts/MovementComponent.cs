using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    public float speed;

    private Rigidbody2D _playerRigidbody;
    private Vector2 movement;


    public void ChangeValues(float horizontal, float vertical)
    {
        movement = new Vector2(horizontal, vertical);
    }

    private void Start()
    {
        movement = Vector2.zero;
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _playerRigidbody.velocity = movement * speed;
    }
}
