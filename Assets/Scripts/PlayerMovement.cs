using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private bool _isGrounded;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _speed = 5f;
        _jumpForce = 2000f;
        _isGrounded = false;
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _rb.velocity = Vector2.right * _speed;
            _animator.SetBool("isRunning", true);
            _spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _rb.velocity = Vector2.left * _speed;
            _animator.SetBool("isRunning", true);
            _spriteRenderer.flipX = true;
        }
        else
        {
            _rb.velocity = Vector2.zero;
            _animator.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.W) && _isGrounded)
        {
            _rb.AddForce(Vector2.up * _jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 8)
        {
            _isGrounded = true;
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == 8)
        {
            _isGrounded = false;
        }
    }
}
