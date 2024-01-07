using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float maxHp => _maxHP;
    public float currentHP => _currentHP;

    [SerializeField] private float _maxHP = 100f;
    [SerializeField] private float _currentHP = 100f;
    [SerializeField] private float attackSpeed = 2f;
    [SerializeField] private float range = 2f;
    [SerializeField] private float detectionRadius = 5f;
    [SerializeField] private float damage = 1f;
    [SerializeField] EnemyMovement movement;

    private bool _isAttacking;

    private void OnEnable()
    {
        _currentHP = _maxHP;

        if(movement == null)
        {
            movement = GetComponent<EnemyMovement>();
        }
        Transform target = transform; // get player
        movement.Init(range, detectionRadius, target);

        movement.WhenInRange += StartAttacking;
        movement.WhenFollow += StopAttacking;
    }

    private void OnDisable()
    {
        movement.WhenInRange += StartAttacking;
        movement.WhenFollow += StopAttacking;
    }

    public virtual void TakeDamage(float pDamage)
    {
        _currentHP -= pDamage;

        if(_currentHP <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        StartCoroutine(I_Die());
    }

    private IEnumerator I_Die()
    {
        yield return new WaitForEndOfFrame();

        Destroy(gameObject);
    }

    private void StartAttacking()
    {
        _isAttacking = true;
        Attack();
        StopCoroutine(I_Attacking());
        StartCoroutine(I_Attacking());
    }

    private void StopAttacking()
    {
        _isAttacking = false;
        StopCoroutine(I_Attacking());
    }

    private IEnumerator I_Attacking()
    {
        float time = 0f;

        while (time <= attackSpeed)
        {
            yield return new WaitForEndOfFrame();

            time += Time.deltaTime;
        }

        if (_isAttacking)
        {
            StartCoroutine(I_Attacking());
        }
    }

    public virtual void Attack()
    {
        Debug.Log("attack: " + _isAttacking);
    }
}
