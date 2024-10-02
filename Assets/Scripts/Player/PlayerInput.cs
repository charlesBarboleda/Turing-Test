using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Execute this before all other scripts
[DefaultExecutionOrder(-100)]
public class PlayerInput : MonoBehaviour
{
    public float horizontal { get; private set; }
    public float vertical { get; private set; }

    public float mouseX { get; private set; }

    public float mouseY { get; private set; }

    public bool sprintHeld { get; private set; }
    public bool jumpPressed { get; private set; }

    public bool interactPressed { get; private set; }

    public bool primaryShootPressed { get; private set; }

    public bool secondaryShootPressed { get; private set; }
    public bool _weapon1Pressed { get; private set; }
    public bool _weapon2Pressed { get; private set; }
    public bool _commandPressed { get; private set; }

    bool _clear;

    /// <summary>
    /// Singleton Pattern
    /// </summary>
    public static PlayerInput Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(this);
        }
    }

    public static PlayerInput GetInstance()
    {
        return Instance;
    }




    // Update is called once per frame
    void Update()
    {
        ClearInput();
        ProcessInputs();
    }

    void ProcessInputs()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        sprintHeld = sprintHeld || Input.GetButton("Fire3");
        jumpPressed = jumpPressed || Input.GetButtonDown("Jump");
        interactPressed = interactPressed || Input.GetKeyDown(KeyCode.E);

        primaryShootPressed = primaryShootPressed || Input.GetMouseButtonDown(0);
        secondaryShootPressed = secondaryShootPressed || Input.GetMouseButtonDown(1);

        _weapon1Pressed = _weapon1Pressed || Input.GetKeyDown(KeyCode.Alpha1);
        _weapon2Pressed = _weapon2Pressed || Input.GetKeyDown(KeyCode.Alpha2);

        _commandPressed = _commandPressed || Input.GetKeyDown(KeyCode.G);
    }

    void FixedUpdate()
    {
        _clear = true;
    }

    void ClearInput()
    {
        if (!_clear) return;

        horizontal = Mathf.Lerp(horizontal, 0, 0.2f);
        vertical = Mathf.Lerp(vertical, 0, 0.2f);
        mouseX = 0;
        mouseY = 0;

        sprintHeld = false;
        jumpPressed = false;
        interactPressed = false;
        primaryShootPressed = false;
        secondaryShootPressed = false;
        _weapon1Pressed = false;
        _weapon2Pressed = false;
        _commandPressed = false;

    }
}
