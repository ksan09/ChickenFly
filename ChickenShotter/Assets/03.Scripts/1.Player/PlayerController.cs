using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputController))]
public class PlayerController : MonoBehaviour
{

    private PlayerInputController _input;

    private Rigidbody2D _playerRigidbody;

    // Player Value
    [Header("Player Info")]
    [SerializeField] private float _jumpPower = 10f;

    private void Awake()
    {

        _input = GetComponent<PlayerInputController>();
        _playerRigidbody = GetComponent<Rigidbody2D>();

        RegisterInput();

    }

    private void RegisterInput()
    {

        _input.OnTouchFunc += HandleJump;

    }

    private void HandleJump()
    {

        if (_playerRigidbody.velocity.y > 5f)
            return;

        _playerRigidbody.velocity = Vector3.zero;
        _playerRigidbody.AddForce(Vector3.up * _jumpPower, ForceMode2D.Impulse);

    }
}
