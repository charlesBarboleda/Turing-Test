using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;


public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] float _moveSpeed;
    [SerializeField] float _sprintMultiplier;
    [SerializeField] float _moveMultiplier;
    [SerializeField] float _turnSpeed;
    [SerializeField] float _verticalSensitivity = 1f;
    [SerializeField] Transform _cameraTransform;
    [SerializeField] bool _invertMouse;
    [SerializeField] float _jumpVelocity;
    [SerializeField] float _gravity = -9.81f;


    [Header("Interactable")]
    Camera _cam;
    RaycastHit _rayCastHit;
    ISelectable _selectable;
    [SerializeField] LayerMask _buttonLayer;
    [SerializeField] float _rayCastDistance;

    [Header("Pick and Drop")]
    [SerializeField] LayerMask _pickableLayer;
    [SerializeField] float _pickUpDistance = 5f;
    [SerializeField] Transform _attachTransform;
    bool isPicked;
    IPickable _pickable;


    [Header("Ground Check")]
    [SerializeField] Transform _groundCheck;
    [SerializeField] LayerMask _groundMask;
    [SerializeField] float _groundCheckDistance;



    [Header("Shooting")]
    [SerializeField] Rigidbody _bulletPrefab;
    [SerializeField] float _shootForce;
    [SerializeField] Transform _shootPoint;


    CharacterController _characterController;

    float _horizontal, _vertical;
    float _mouseX, _mouseY;
    float _camXRotation;
    Vector3 _playerVelocity;
    bool _isGrounded;
    void Start()
    {
        _cam = Camera.main;
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
        Interact();
        PickAndDrop();
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
        // Turning Player (Horizontal)
        transform.Rotate(Vector3.up * _turnSpeed * Time.deltaTime * _mouseX);

        // Camera Up and Down (Vertical) with new vertical sensitivity
        _camXRotation += Time.deltaTime * _mouseY * _verticalSensitivity * (_invertMouse ? 1 : -1);
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

    void Interact()
    {
        Ray ray = _cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out _rayCastHit, _rayCastDistance, _buttonLayer))
        {
            _selectable = _rayCastHit.transform.GetComponent<ISelectable>();
            if (_selectable != null)
            {
                _selectable.OnHover();
                Debug.Log("Hovering over selectable");

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("E Pressed");
                    _selectable.OnSelect();
                }
            }
        }
        if (_rayCastHit.transform == null && _selectable != null)
        {
            _selectable.OnHoverExit();
            _selectable = null;
        }
    }

    void PickAndDrop()
    {
        Ray ray = _cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out _rayCastHit, _pickUpDistance, _pickableLayer))
        {
            _pickable = _rayCastHit.transform.GetComponent<IPickable>();
            if (_pickable != null)
            {
                if (Input.GetKeyDown(KeyCode.E) && !isPicked)
                {
                    _pickable.onPicked(_attachTransform);
                    isPicked = true;
                    return;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && isPicked && _pickable != null)
        {
            _pickable.onDropped();
            isPicked = false;
        }
    }
}

