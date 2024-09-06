using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShootStrategy : IShootStrategy
{
    ShootInteractor _interactor;
    Transform _shootPoint;
    public BulletShootStrategy(ShootInteractor interactor)
    {
        Debug.Log("Switched to Bullet Mode");
        _interactor = interactor;
        _shootPoint = _interactor.GetShootPoint();

        // Change Gun Colour

        _interactor._gunRenderer.material.color = _interactor._bulletGunColour;
    }
    public void Shoot()
    {
        PooledObject pooledBullet = _interactor.bulletPool.GetPooledObject();
        pooledBullet.gameObject.SetActive(true);

        Rigidbody bulletRb = pooledBullet.GetComponent<Rigidbody>();
        bulletRb.transform.position = _shootPoint.position;
        bulletRb.transform.rotation = _shootPoint.rotation;

        bulletRb.velocity = _shootPoint.forward * _interactor.GetShootVelocity();
        _interactor.bulletPool.DestroyPooledObject(pooledBullet, 5.0f);
    }
}
