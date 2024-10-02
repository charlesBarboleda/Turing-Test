using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour, ISelectable
{
    public Material _unlockedColor;
    public Material _lockedColor;
    public MeshRenderer _renderer;
    public Animator doorAnim;
    public KeyManager keyManager;
    public UnityEvent _onPush;
    public int keyIndex;



    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _lockedColor = _renderer.material;
    }

    public void OpenDoor()
    {
        doorAnim.SetBool("isOpen", true);
    }
    public void CloseDoor()
    {
        doorAnim.SetBool("isOpen", false);
    }
    public void OnHover()
    {
        _renderer.material = _unlockedColor;
    }

    public void OnHoverExit()
    {
        _renderer.material = _lockedColor;
    }

    public void OnSelect()
    {
        Debug.Log("Button Pressed");
        if (keyManager.HasKey(keyManager.keys[keyIndex]))
        {
            Debug.Log("Player has key... opening the door");
            _onPush.Invoke();
        }
    }

}
