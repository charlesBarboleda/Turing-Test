using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorIndicator : MonoBehaviour
{
    public MeshRenderer _renderer;
    public Material _unlockedColor;
    public Material _lockedColor;

    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _lockedColor = _renderer.material;
    }

    public void ChangeColorToUnlock()
    {
        _renderer.material = _unlockedColor;
    }

    public void ChangeColorToLock()
    {
        _renderer.material = _lockedColor;
    }



}
