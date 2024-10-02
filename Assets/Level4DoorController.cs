using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4DoorController : MonoBehaviour
{
    Animator _animator;


    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        _animator.SetBool("isOpen", true);
    }
    public void CloseDoor()
    {
        _animator.SetBool("isOpen", false);
    }
}
