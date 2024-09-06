using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float _maxHealth;

    public Action<float> OnHealthUpdated;
    public Action OnDeath;

    public bool isDead { get; private set; }
    float _health;

    void Start()
    {
        _health = _maxHealth;
        OnHealthUpdated(_maxHealth);
    }

    public void DeductHealth(float amount)
    {
        if (isDead) return;

        _health -= amount;

        if (_health <= 0)
        {
            isDead = true;
            OnDeath();
            _health = 0;
        }
        OnHealthUpdated(_health);
    }
}
