using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    EnemyState _currentState;
    public Transform enemy;
    public float _playerCheckDistance;
    public float _checkRadius;
    public float _aggroDistance;
    public Transform[] _targetPoints;

    public NavMeshAgent _agent;

    public Transform _player;



    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _currentState = new EnemyIdleState(this);
        _currentState.OnStateEnter();
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.OnStateUpdate();
    }

    public void ChangeState(EnemyState newState)
    {
        _currentState.OnStateExit();
        _currentState = newState;
        _currentState.OnStateEnter();
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemy.position, _checkRadius);
        Gizmos.DrawWireSphere(enemy.position + enemy.forward * _playerCheckDistance, _checkRadius);

        Gizmos.DrawLine(enemy.position, enemy.position + enemy.forward * _playerCheckDistance);

    }
}
