using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInteractor : Interactor
{
    [Header("Gun")]
    public MeshRenderer _gunRenderer;
    public Color _bulletGunColour;
    public Color _rocketGunColour;


    [Header("Shoot")]
    [SerializeField] public ObjectPool bulletPool;
    [SerializeField] public ObjectPool rocketPool;

    [SerializeField] Rigidbody _bulletPrefab;
    [SerializeField] float _shootVelocity;
    [SerializeField] Transform _shootPoint;
    [SerializeField] PlayerMovementBehaviour _playerMovementBehaviour;

    float _finalShootVelocty;
    IShootStrategy _currentShootStrategy;
    public override void Interact()
    {
        // Default shoot strategy
        if (_currentShootStrategy == null) _currentShootStrategy = new BulletShootStrategy(this);

        // Change strategy
        if (_input._weapon1Pressed) _currentShootStrategy = new BulletShootStrategy(this);

        if (_input._weapon2Pressed) _currentShootStrategy = new RocketShootStrategy(this);

        // Shoot with the current strategy

        if (_input.primaryShootPressed && _currentShootStrategy != null) _currentShootStrategy.Shoot();



    }

    public Transform GetShootPoint() => _shootPoint;
    public float GetShootVelocity()
    {
        _finalShootVelocty = _playerMovementBehaviour.GetForwardVelocity() + _shootVelocity;
        return _finalShootVelocty;
    }


}
