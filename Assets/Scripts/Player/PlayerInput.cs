using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
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

    bool _clear;




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
    }

    void FixedUpdate()
    {
        _clear = true;
    }

    void ClearInput()
    {
        if (!_clear) return;

        horizontal = 0;
        vertical = 0;
        mouseX = 0;
        mouseY = 0;

        sprintHeld = false;
        jumpPressed = false;
        interactPressed = false;
        primaryShootPressed = false;
        secondaryShootPressed = false;

    }
}
