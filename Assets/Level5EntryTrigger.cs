using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level5EntryTrigger : MonoBehaviour
{
    public UnityEvent OnPlayerEnter;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPlayerEnter.Invoke();
            Destroy(gameObject);
        }
    }
}
