using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementBehaviour : MonoBehaviour
{
    PlayerInput _input;

    [Header("Player Movement")]
    [SerializeField] float _moveSpeed;
    [SerializeField] float _sprintMultiplier;
    [SerializeField] float _moveMultiplier;
    [SerializeField] float _gravity = -9.81f;

    [Header("Ground Check")]
    [SerializeField] Transform _groundCheck;
    [SerializeField] LayerMask _groundMask;
    [SerializeField] float _groundCheckDistance;
    public bool _isGrounded { get; private set; }
    public Vector3 _playerVelocity;

    CharacterController _characterController;



    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _input = PlayerInput.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        GroundCheck();

    }

    void MovePlayer()
    {
        _moveMultiplier = _input.sprintHeld ? _sprintMultiplier : 1f;

        _characterController.Move((transform.forward * _input.vertical + transform.right * _input.horizontal) * _moveSpeed * Time.deltaTime * _moveMultiplier);

        // Ground Check
        if (_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = -2f;
        }

        _playerVelocity.y += _gravity * Time.deltaTime;

        _characterController.Move(_playerVelocity * Time.deltaTime);


    }

    void GroundCheck()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundCheckDistance, _groundMask);
    }

    public void SetYVelocity(float yVelocity)
    {
        _playerVelocity.y = yVelocity;
    }

    public float GetForwardVelocity()
    {
        return _input.vertical * _moveSpeed * _moveMultiplier;
    }
}
