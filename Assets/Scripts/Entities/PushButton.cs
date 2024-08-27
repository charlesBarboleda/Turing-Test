using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButton : MonoBehaviour, ISelectable
{
    [SerializeField] Material _hoverColor;
    [SerializeField] Animator _movingPlatformAnimator;
    MeshRenderer _renderer;
    Material _defaultColor;

    public UnityEvent _onPush;

    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _defaultColor = _renderer.material;
    }
    public void isActiveAnimationTrue()
    {
        _movingPlatformAnimator.SetBool("isActive", true);
    }
    public void isActiveAnimationFalse()
    {
        _movingPlatformAnimator.SetBool("isActive", false);
    }
    public void OnHover()
    {
        _renderer.material = _hoverColor;
    }

    public void OnHoverExit()
    {
        _renderer.material = _defaultColor;
    }

    public void OnSelect()
    {
        // Turn on isActive animation bool
        _onPush.Invoke();
    }

}
