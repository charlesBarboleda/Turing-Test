using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorKey : MonoBehaviour
{
    public UnityEvent<DoorKey> onKeyPickedUp;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            onKeyPickedUp.Invoke(this);
            Destroy(gameObject);
        }
    }


}
