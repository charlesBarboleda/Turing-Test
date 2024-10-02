using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] GameObject _objectToSpawn;
    [SerializeField] Transform _spawnPoint;


    public void SpawnObjectAtPoint()
    {
        Instantiate(_objectToSpawn, _spawnPoint.position, _spawnPoint.rotation);
    }
}
