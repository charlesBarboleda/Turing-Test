using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactor : MonoBehaviour
{
    protected PlayerInput _input;


    void Start()
    {
        _input = PlayerInput.GetInstance();
    }
    // Update is called once per frame
    void Update()
    {
        Interact();
    }

    public abstract void Interact();
}
