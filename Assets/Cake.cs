using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cake : MonoBehaviour, ISelectable
{
    MeshRenderer _meshRenderer;
    Material _originalMaterial;
    [SerializeField] Material _inActiveMaterial;
    [SerializeField] Material _hoverMaterial;
    public UnityEvent OnCakeSelect;
    public bool isActive;


    void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _originalMaterial = _meshRenderer.material;
        _meshRenderer.material = _inActiveMaterial;
    }
    public void OnHover()
    {
        if (isActive)
        {
            _meshRenderer.material = _hoverMaterial;
            UIManager.Instance.PressEHover();
        }
    }

    public void OnHoverExit()
    {
        if (isActive)
        {
            _meshRenderer.material = _originalMaterial;
            UIManager.Instance.PressEHoverExit();
        }
    }

    public void OnSelect()
    {
        if (isActive)
            OnCakeSelect.Invoke();
    }

    public void ActivateCake()
    {
        isActive = true;
        _meshRenderer.material = _originalMaterial;
    }
}
