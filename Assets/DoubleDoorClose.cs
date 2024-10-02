using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoorClose : MonoBehaviour
{
    [SerializeField] Animator _animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _animator.SetBool("isOpen", false);
        }
    }
}
