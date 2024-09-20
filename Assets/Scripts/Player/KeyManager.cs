using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public List<DoorKey> keys = new List<DoorKey>();


    public bool HasKey(DoorKey key)
    {
        return keys.Contains(key);
    }
    public void AddKey(DoorKey key)
    {
        keys.Add(key);
        Debug.Log("Added Key");
    }

    public void RemoveKey(DoorKey key)
    {
        keys.Remove(key);
        Debug.Log("Removed Key");
    }
}
