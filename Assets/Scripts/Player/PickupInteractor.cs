using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInteractor : Interactor
{
    [SerializeField] LayerMask _interactableLayer;
    [SerializeField] Camera _cam;
    [SerializeField] float _interactionDistance;
    [SerializeField] Transform _attachTransform;

    RaycastHit _rayCastHit;
    IPickable _pickable;
    IPickable _currentlyHeldItem;  // Track the currently picked-up object

    void Update()
    {
        Interact();
    }

    public override void Interact()
    {
        if (_input.interactPressed)
        {
            // Check if we are already holding an item
            if (_currentlyHeldItem != null)
            {
                // Drop the currently held item
                _currentlyHeldItem.onDropped();
                _currentlyHeldItem = null;  // Clear the reference
                return;  // Exit the method after dropping
            }

            // Cast a ray to check if we are interacting with an object
            Ray ray = _cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

            if (Physics.Raycast(ray, out _rayCastHit, _interactionDistance, _interactableLayer))
            {
                _pickable = _rayCastHit.transform.GetComponent<IPickable>();

                // Pick up the object if it implements IPickable
                if (_pickable != null)
                {
                    _pickable.onPicked(_attachTransform);
                    _currentlyHeldItem = _pickable;  // Set the currently held item
                }
            }
        }
    }
}
