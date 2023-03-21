using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMoveAim : MonoBehaviour
{
    public float speed;

    private Rigidbody2D _playerRigidbody;
    private Vector2 movement;
    private Animator _animator;
    private void Start()
    {
        _playerRigidbody=  gameObject.GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _animator.SetBool("Sweat", false);
    }
    void Update()
    {

    }
    private void FixedUpdate()
    {
        _playerRigidbody.velocity = new Vector2(0, speed);
        _animator.SetFloat("Vertical", -1);
    }
}
