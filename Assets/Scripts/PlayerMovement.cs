using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private bool _isGrounded;
    
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _speed = 5f;
        _jumpForce = 2000f; 
        _isGrounded = false;
        
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            HorizontalMove(Vector2.right);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            HorizontalMove(Vector2.left);
        }
        else
        {
            _rigidbody2D.velocity = Vector2.zero;
            _animator.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.W) && _isGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }

    private void HorizontalMove(Vector2 direction)
    {
        _rigidbody2D.velocity = direction * _speed;
        _animator.SetBool("isRunning", true);

        if (direction == Vector2.right)
        {
            _spriteRenderer.flipX = false;
        }
        else
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Ground ground;
        
        if (TryGetComponent(out ground))
        {
            _isGrounded = true;
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        Ground ground;
        
        if (TryGetComponent(out ground))
        {
            _isGrounded = false;
        }
    }
}
