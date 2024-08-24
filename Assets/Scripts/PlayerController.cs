using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _sprintMultiplier;
    [SerializeField] private float _moveMultiplier;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private bool _invertMouse;
    [SerializeField] private float _jumpVelocity;
    [SerializeField] private float _gravity = -9.81f;






    [Header("Ground Check")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _groundCheckDistance;



    [Header("Shooting")]
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private float _shootForce;
    [SerializeField] private Transform _shootPoint;


    private CharacterController _characterController;

    private float _horizontal, _vertical;
    private float _mouseX, _mouseY;
    private float _camXRotation;
    private Vector3 _playerVelocity;
    private bool _isGrounded;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();

        // Hide and lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        GetInput();
        MovePlayer();
        RotatePlayer();
        GroundCheck();
        JumpCheck();
        ShootBullet();
    }

    void GetInput()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        _mouseX = Input.GetAxisRaw("Mouse X");
        _mouseY = Input.GetAxisRaw("Mouse Y");
        _moveMultiplier = Input.GetButton("Fire3") ? _sprintMultiplier : 1;

    }

    void MovePlayer()
    {
        _characterController.Move((transform.forward * _vertical + transform.right * _horizontal) * _moveSpeed * Time.deltaTime * _moveMultiplier);

        // Ground Check
        if (_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = -2f;
        }

        _playerVelocity.y += _gravity * Time.deltaTime;

        _characterController.Move(_playerVelocity * Time.deltaTime);

    }

    void RotatePlayer()
    {
        // Turning Player
        transform.Rotate(Vector3.up * _turnSpeed * Time.deltaTime * _mouseX);

        // Camera Up and Down
        _camXRotation += Time.deltaTime * _mouseY * _turnSpeed * (_invertMouse ? 1 : -1);
        _camXRotation = Mathf.Clamp(_camXRotation, -85f, 85f);

        _cameraTransform.localRotation = Quaternion.Euler(_camXRotation, 0, 0);
    }

    void GroundCheck()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundCheckDistance, _groundMask);
    }

    void JumpCheck()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _playerVelocity.y = _jumpVelocity;
        }
    }

    void ShootBullet()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody bullet = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);

            bullet.velocity = _cameraTransform.forward * _shootForce;
            Destroy(bullet.gameObject, 5.0f);
        }
    }
}
