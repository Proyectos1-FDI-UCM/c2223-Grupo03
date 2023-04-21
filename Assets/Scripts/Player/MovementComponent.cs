using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class MovementComponent : MonoBehaviour
{
    public float speed;
    private float oldSpeed;

    private Rigidbody2D _playerRigidbody;
    private Vector2 movement;
    private Animator _animator;
    private AudioSource _audioSource;

    public void ChangeValues(Vector2 vector)
    {
        movement = vector;
    }
    public void Pause()
    {
        if (!GameManager.Instance.IsPause)
        {
            oldSpeed = speed;
            speed = 0;
        }
        else
        {
            speed = oldSpeed;
        }

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
