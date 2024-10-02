using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysButton : MonoBehaviour, ISelectable
{
    [SerializeField] SimonSaysManager _simonSaysManager;
    public void OnHover()
    {
        // No need for implementation
    }

    public void OnHoverExit()
    {
        // No need for implementation
    }

    public void OnSelect()
    {
        _simonSaysManager.ResetPuzzle();
    }

}
