using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRaycast : MonoBehaviour
{
    RaycastHit hit;
    LineRenderer _lineRenderer;
    Vector3 _laserHitPoint;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Transform _laserStartPoint;



    void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {

        if (Physics.Raycast(transform.position, _laserStartPoint.forward, out hit, Mathf.Infinity, layerMask))
        {
            _laserHitPoint = hit.point;
        }
        else
        {
            _laserHitPoint = transform.position + transform.forward * 1000;
        }
        _lineRenderer.SetPosition(0, _laserStartPoint.position);
        _lineRenderer.SetPosition(1, _laserHitPoint);
    }
}
