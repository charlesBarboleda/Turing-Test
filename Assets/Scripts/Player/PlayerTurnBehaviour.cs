using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerTurnBehaviour : MonoBehaviour
{
    PlayerInput _input;

    [Header("Player Turn")]
    [SerializeField] float _turnSpeed;

    void Start()
    {
        _input = PlayerInput.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
    }

    void RotatePlayer()
    {
        // Turning Player
        transform.Rotate(Vector3.up * _turnSpeed * Time.deltaTime * _input.mouseX);

    }
}
