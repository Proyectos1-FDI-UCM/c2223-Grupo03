using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    public float speed;
    private Rigidbody2D _playerRigidbody;

    public float horizontalAxis;
    public float verticalAxis;
    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        

        Vector2 movement = new Vector2(horizontalAxis, verticalAxis);
        _playerRigidbody.velocity = movement * speed;
    }
}
