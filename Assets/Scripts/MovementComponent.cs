using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    public float speed;

    private Rigidbody2D _playerRigidbody;
    private Vector2 movement;
    private Animator _animator;
    private AudioSource _audioSource;


    public void ChangeValues(float horizontal, float vertical)
    {
        movement = new Vector2(horizontal, vertical);
       
    }

    private void Update()
    {
        _animator.SetFloat("Horizontal", movement.x);
        _animator.SetFloat("Vertical", movement.y);

    }
    private void Start()
    {
        movement = Vector2.zero;
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        _playerRigidbody.velocity = movement * speed;

    }
}
