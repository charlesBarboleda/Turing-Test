using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    [SerializeField] LevelManager _endingLevel;
    [SerializeField] GameObject _objToDestroy;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _endingLevel.EndLevel();
            Destroy(gameObject);
            Destroy(_objToDestroy);
        }
    }
}
