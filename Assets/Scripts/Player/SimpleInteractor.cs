using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInteractor : Interactor
{
    [Header("Interact")]
    [SerializeField] LayerMask _interactableLayer;
    [SerializeField] Camera _cam;
    [SerializeField] float _interactionDistance;

    RaycastHit _rayCastHit;
    ISelectable _selectable;
    void Update()
    {
        Interact();
    }
    public override void Interact()
    {
        Ray ray = _cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out _rayCastHit, _interactionDistance, _interactableLayer))
        {
            _selectable = _rayCastHit.transform.GetComponent<ISelectable>();
            if (_selectable != null)
            {
                _selectable.OnHover();
                Debug.Log("Hovering over selectable");

                if (_input.interactPressed)
                {
                    Debug.Log("E Pressed");
                    _selectable.OnSelect();
                }
            }
        }
        if (_rayCastHit.transform == null && _selectable != null)
        {
            _selectable.OnHoverExit();
            _selectable = null;
        }
    }
}
