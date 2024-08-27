using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(PlayerMovementBehaviour))]
public class PlayerJumpBehaviour : SimpleInteractor
{

    [Header("Jump")]
    [SerializeField] float _jumpVelocity;

    PlayerMovementBehaviour _playerMovementBehaviour;
    void Start()
    {
        _playerMovementBehaviour = GetComponent<PlayerMovementBehaviour>();
    }

    public override void Interact()
    {
        if (_input.jumpPressed && _playerMovementBehaviour._isGrounded)
        {
            _playerMovementBehaviour.SetYVelocity(_jumpVelocity);
        }
    }
}
