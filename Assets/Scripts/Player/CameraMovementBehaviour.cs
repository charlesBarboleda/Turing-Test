using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


[RequireComponent(typeof(Camera))]
public class CameraMovementBehaviour : MonoBehaviour
{
    [SerializeField] PlayerInput _input;

    [Header("Player Turn")]
    [SerializeField] float _turnSpeed;
    [SerializeField] bool _invertMouse;
    float _camXRotation;


    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        _camXRotation += Time.deltaTime * _input.mouseY * _turnSpeed * (_invertMouse ? 1 : -1);
        _camXRotation = Mathf.Clamp(_camXRotation, -85f, 85f);

        transform.localRotation = Quaternion.Euler(_camXRotation, 0, 0);
    }
}
