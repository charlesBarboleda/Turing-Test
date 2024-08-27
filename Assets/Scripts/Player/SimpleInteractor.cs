using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SimpleInteractor : MonoBehaviour
{
    [SerializeField] protected PlayerInput _input;
    void Start()
    {
        Interact();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public abstract void Interact();
}
