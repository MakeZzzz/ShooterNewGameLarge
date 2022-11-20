using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 3f;
    [SerializeField] private CharacterController _controller;

    [SerializeField]private Animator _animator;

    private static readonly int Speed = Animator.StringToHash("speed");
    private static readonly int Left = Animator.StringToHash("left");
    private static readonly int Right = Animator.StringToHash("right");

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        _controller.Move(move * _movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
        {
            _animator.SetFloat(Speed, 1);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _animator.SetFloat(Speed, -1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _animator.SetBool(Left,true);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            _animator.SetBool(Right,true);
        }
    }

    private void FixedUpdate()
    {
        _animator.SetFloat(Speed, 0);
        _animator.SetBool(Left,false);
        _animator.SetBool(Right,false);
    }
}
