using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    public float speed;
    private Rigidbody2D _playerRigidbody;


    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalAxis, verticalAxis);
        _playerRigidbody.velocity = movement * speed;
    }
}
