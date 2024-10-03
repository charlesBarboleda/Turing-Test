using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class level2roomclosetrigger : MonoBehaviour
{
    public UnityEvent OnPlayerEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPlayerEnter.Invoke();
        }
    }
}
