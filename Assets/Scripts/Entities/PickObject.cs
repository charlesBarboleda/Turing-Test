using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObject : MonoBehaviour, IPickable
{
    FixedJoint _joint;
    Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void onPicked(Transform attachTransform)
    {
        transform.position = attachTransform.position;
        transform.SetParent(attachTransform);

        _rigidbody.isKinematic = true;
        _rigidbody.useGravity = false;
    }
    public void onDropped()
    {
        // Destroy(_joint);
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;
        transform.SetParent(null);
    }



}
