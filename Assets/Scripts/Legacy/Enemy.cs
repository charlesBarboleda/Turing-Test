using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform[] _targetPoints;
    [SerializeField] Transform _player;
    [SerializeField] Transform _enemy;
    [SerializeField] float _playerCheckDistance = 10f;
    [SerializeField] float _aggroDistance = 5f;
    [SerializeField] float _checkRadius = 0.4f;
    NavMeshAgent _navMeshAgent;

    int _currentTarget = 0;


    public bool isIdle = true;
    public bool isPlayerFound;
    public bool isCloseToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.destination = _targetPoints[_currentTarget].position;

    }

    // Update is called once per frame
    void Update()
    {
        if (isIdle)
        {
            Idle();
        }
        else if (isPlayerFound)
        {
            if (isCloseToPlayer)
            {
                AttackPlayer();
            }
            else
            {
                FollowPlayer();
            }
        }
    }

    void FollowPlayer()
    {
        if (_player != null)
        {
            if (Vector3.Distance(transform.position, _player.position) > _playerCheckDistance)
            {
                isPlayerFound = false;
                isIdle = true;
            }
            // Attack
            if (Vector3.Distance(transform.position, _player.position) <= _playerCheckDistance / 5)
            {
                isCloseToPlayer = true;
            }
            else
            {
                isCloseToPlayer = false;
            }
            _navMeshAgent.destination = _player.position;
        }
        else
        {
            isPlayerFound = false;
            isIdle = true;
            isCloseToPlayer = false;
        }
    }

    void Idle()
    {
        if (_navMeshAgent.remainingDistance < 0.1f)
        {
            _currentTarget++;
            if (_currentTarget >= _targetPoints.Length) _currentTarget = 0;

            _navMeshAgent.destination = _targetPoints[_currentTarget].position;
        }

        if (Physics.SphereCast(_enemy.position, _checkRadius, transform.forward, out RaycastHit hit, _aggroDistance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Debug.Log("Player Found");
                isPlayerFound = true;
                isIdle = false;
                _player = hit.transform;
                _navMeshAgent.destination = _player.position;
            }
        }
    }

    void AttackPlayer()
    {
        Debug.Log("Attacking Player");
        if (Vector3.Distance(transform.position, _player.position) > _playerCheckDistance / 5)
        {
            isCloseToPlayer = false;
            isPlayerFound = false;
            isIdle = true;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_enemy.position, _checkRadius);
        Gizmos.DrawWireSphere(_enemy.position + _enemy.forward * _playerCheckDistance, _checkRadius);

        Gizmos.DrawLine(_enemy.position, _enemy.position + _enemy.forward * _playerCheckDistance);
    }
}
