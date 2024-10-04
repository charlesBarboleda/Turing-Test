using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysButton : MonoBehaviour, ISelectable
{
    [SerializeField] SimonSaysManager _simonSaysManager;
    public void OnHover()
    {
        UIManager.Instance.PressEHover();
    }

    public void OnHoverExit()
    {
        UIManager.Instance.PressEHoverExit();
    }

    public void OnSelect()
    {
        _simonSaysManager.ResetPuzzle();
    }

}
