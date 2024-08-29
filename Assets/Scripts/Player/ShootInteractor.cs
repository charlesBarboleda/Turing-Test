using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInteractor : Interactor
{
    [SerializeField] Input _inputType;
    [Header("Shooting")]
    [SerializeField] ObjectPool _bulletPool;
    [SerializeField] Rigidbody _bulletPrefab;
    [SerializeField] float _shootVelocity;
    [SerializeField] Transform _shootPoint;
    [SerializeField] PlayerMovementBehaviour _playerMovementBehaviour;

    float _finalShootVelocty;
    public enum Input
    {
        Primary,
        Secondary
    }
    public override void Interact()
    {
        if (_inputType == Input.Primary && _input.primaryShootPressed || _inputType == Input.Secondary && _input.secondaryShootPressed)
        {
            Shoot();
        }

    }

    void Shoot()
    {
        _finalShootVelocty = _playerMovementBehaviour.GetForwardVelocity() + _shootVelocity;

        PooledObject pooledBullet = _bulletPool.GetPooledObject();
        pooledBullet.gameObject.SetActive(true);

        Rigidbody bulletRb = pooledBullet.GetComponent<Rigidbody>();
        bulletRb.transform.position = _shootPoint.position;
        bulletRb.transform.rotation = _shootPoint.rotation;

        bulletRb.velocity = _shootPoint.forward * _finalShootVelocty;
        _bulletPool.DestroyPooledObject(pooledBullet, 5.0f);
    }
}
