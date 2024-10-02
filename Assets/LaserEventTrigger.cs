using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserEventTrigger : MonoBehaviour
{
    [SerializeField] Material _greenMaterial;
    MeshRenderer _meshRenderer;
    public UnityEvent onLaserHit;
    bool _isTriggered = false;

    void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    public void OnLaserHit()
    {
        if (_isTriggered) return;
        onLaserHit.Invoke();
        _isTriggered = true;
        _meshRenderer.material = _greenMaterial;
    }
}
