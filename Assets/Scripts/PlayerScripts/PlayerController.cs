using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public Action OnMove;

    private CharacterController _controller;
    private InputManager _inputManager;
    private Vector3 _playerVelocity;
    private bool _groundedPlayer;

    public float playerSpeed = 2.0f;
    public float gravityValue = -9.81f;

    void Start() {
        _inputManager = InputManager.GetInstance();
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        _groundedPlayer = _controller.isGrounded;
        if (_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        Vector2 movement = _inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = Camera.main.transform.forward * move.z + Camera.main.transform.right * move.x;
        move.y = 0f;

        if (move.magnitude > 0) {
            if (OnMove != null)
                OnMove.Invoke();
        }

        move.Normalize();

        _controller.Move(move * Time.deltaTime * playerSpeed);

        _playerVelocity.y += gravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
    }
}