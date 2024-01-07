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

    public void Init(float pRange, float pDetectionRadius, float pMoveSpeed, Transform pTarget)
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;


        _range = pRange;
        _detectionRadius = pDetectionRadius;
        _target = pTarget;
        _moveSpeed = pMoveSpeed;

        _agent.stoppingDistance = _range;
        //_agent.speed = _moveSpeed;
    }

    private void LateUpdate()
    {
        if ((_target.position - transform.position).magnitude <= _detectionRadius || _detectedPlayer)
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
