using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmoHelper : MonoBehaviour
{
    [SerializeField] float _size = 0.5f;
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _size);
    }
}
