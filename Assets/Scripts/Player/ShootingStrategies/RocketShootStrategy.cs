using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShootStrategy : IShootStrategy
{
    ShootInteractor _interactor;
    Transform _shootPoint;
    public RocketShootStrategy(ShootInteractor interactor)
    {
        Debug.Log("Switched to Rocket Mode");
        this._interactor = interactor;
        this._shootPoint = interactor.GetShootPoint();
        interactor._gunRenderer.material.color = interactor._rocketGunColour;
    }
    public void Shoot()
    {
        PooledObject pooledRocket = _interactor.rocketPool.GetPooledObject();
        pooledRocket.gameObject.SetActive(true);

        Rigidbody rocketRb = pooledRocket.GetComponent<Rigidbody>();
        rocketRb.transform.position = _shootPoint.position;
        rocketRb.transform.rotation = _shootPoint.rotation;

        rocketRb.velocity = _shootPoint.forward * _interactor.GetShootVelocity();
        _interactor.rocketPool.DestroyPooledObject(pooledRocket, 5.0f);
    }
}
