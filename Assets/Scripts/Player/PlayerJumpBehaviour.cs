using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(PlayerMovementBehaviour))]
public class PlayerJumpBehaviour : Interactor
{

    [Header("Jump")]
    [SerializeField] float _jumpVelocity;

    PlayerMovementBehaviour _playerMovementBehaviour;
    void Start()
    {
        _playerMovementBehaviour = GetComponent<PlayerMovementBehaviour>();
        _input = PlayerInput.GetInstance();
    }

    public override void Interact()
    {
        if (_input.jumpPressed && _playerMovementBehaviour._isGrounded)
        {
            _playerMovementBehaviour.SetYVelocity(_jumpVelocity);
        }
    }
}
