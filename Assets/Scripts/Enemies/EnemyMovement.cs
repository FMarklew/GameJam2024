using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform _target;
    public UnityAction WhenInRange;
    public UnityAction WhenFollow;
    private NavMeshAgent _agent;

    private float _range;
    private float _detectionRadius;
    private float _moveSpeed;
    private bool _detectedPlayer;
    private bool _isInRange;
    private EnemyBase _enemy;

    public void Init(float pRange, float pDetectionRadius, float pMoveSpeed, Transform pTarget, EnemyBase pEnemy)
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;


        _range = pRange;
        _detectionRadius = pDetectionRadius;
        _target = pTarget;
        _moveSpeed = pMoveSpeed;
        _enemy = pEnemy;

        _agent.stoppingDistance = _range;
        _agent.speed = _moveSpeed;
    }

    private void Update()
    {
        if ((_target.position - transform.position).magnitude <= _detectionRadius || _detectedPlayer || _enemy.health < _enemy.maxHealth)
        {
            _detectedPlayer = true;
            if((_target.position - transform.position).magnitude <= _range && !_isInRange)
            {
                _isInRange = true;
                WhenInRange?.Invoke();
            }
            else if((_target.position - transform.position).magnitude > _range)
            {
                _isInRange = false;
                FollowPlayer();
            }
        }
    }

    private void FollowPlayer()
    {
        WhenFollow?.Invoke();
        _agent.SetDestination(new Vector3(_target.position.x, _target.position.y, transform.position.z));
    }
}
