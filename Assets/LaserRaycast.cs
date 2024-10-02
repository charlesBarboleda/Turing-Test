using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRaycast : MonoBehaviour
{
    RaycastHit hit;
    LineRenderer _lineRenderer;
    int _numberofReflections = 3;  // Number of reflections allowe
    [SerializeField] LayerMask layerMask;
    [SerializeField] Transform _laserStartPoint;
    [SerializeField] Transform _player;
    [SerializeField] Transform _playerSpawnPoint;

    void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    void FixedUpdate()
    {
        Vector3 direction = _laserStartPoint.forward;  // Initial direction
        Vector3 origin = _laserStartPoint.position;    // Start position

        // Set the LineRenderer initial position
        _lineRenderer.positionCount = 1;
        _lineRenderer.SetPosition(0, origin);

        // Perform reflections
        for (int i = 0; i <= _numberofReflections; i++)
        {
            // Cast a ray from the origin in the current direction
            if (Physics.Raycast(origin, direction, out hit, Mathf.Infinity, layerMask))
            {
                // Handle hitting the player
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("Player hit by laser");

                    if (_player != null)
                    {
                        _player.position = _playerSpawnPoint.position;  // Respawn player
                    }
                }
                if (hit.collider.CompareTag("LaserTarget"))
                {
                    Debug.Log("Hitting Laser Target");
                    hit.collider.GetComponent<LaserEventTrigger>().OnLaserHit();
                }

                // Handle reflecting off PickObject
                if (hit.collider.CompareTag("ReflectionObject"))
                {
                    Debug.Log("Hit PickObject, reflecting");

                    // Add a new point to the LineRenderer
                    _lineRenderer.positionCount++;
                    _lineRenderer.SetPosition(i + 1, hit.point);

                    // Calculate the new reflection direction
                    direction = Vector3.Reflect(direction, hit.normal);

                    // Update origin to the hit point for the next reflection
                    origin = hit.point;
                }
                else
                {
                    // Stop reflecting if it's not a PickObject
                    _lineRenderer.positionCount++;
                    _lineRenderer.SetPosition(i + 1, hit.point);
                    break;
                }
            }
            else
            {
                // If no hit, extend the laser in the current direction
                _lineRenderer.positionCount++;
                _lineRenderer.SetPosition(i + 1, origin + direction * 1000f);  // Extend far if no hit
                break;
            }
        }
    }
}
