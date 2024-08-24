

using UnityEngine;

public interface IPickable
{
    public void onPicked(Transform attachTransform);
    public void onDropped();
}

