using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] GameObject _objectToBuild;
    [SerializeField] Transform _placementPoint;

    public void Build()
    {
        Instantiate(_objectToBuild, _placementPoint.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
