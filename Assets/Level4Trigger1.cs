using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level4Trigger1 : MonoBehaviour
{
    public UnityEvent spawnCube;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spawnCube.Invoke();
            Destroy(gameObject);
        }
    }
}
