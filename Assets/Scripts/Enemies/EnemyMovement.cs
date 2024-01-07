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

    private float range;
    private float detectionRadius;
    private bool _detectedPlayer;
    private bool _isInRange;

    public void Init(float pRange, float pDetectionRadius, Transform pTarget)
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;


        range = pRange;
        detectionRadius = pDetectionRadius;
        _target = pTarget;

        _agent.stoppingDistance = range;
    }

    private void Update()
    {
        if ((_target.position - transform.position).magnitude <= detectionRadius || _detectedPlayer)
        {
            _detectedPlayer = true;
            if((_target.position - transform.position).magnitude <= range && !_isInRange)
            {
                _isInRange = true;
                WhenInRange?.Invoke();
            }
            else if((_target.position - transform.position).magnitude > range)
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
