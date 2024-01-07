using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private const float DETECTION_BASE = 3f;

    public int maxHealth => _maxHealth;
    public int health => _health;

    [SerializeField] protected int _maxHealth = 100;
    [SerializeField] protected int _health = 100;
    [SerializeField] protected float _attackSpeed = 2f;
    [SerializeField] protected float _range = 2f;
    [SerializeField] protected float _detectionRadius = 0f;
    [SerializeField] protected float _moveSpeed = 3.5f;
    [SerializeField] protected EnemyMovement _movement;
    [SerializeField] protected BaseAbility _attackAbility;
    [SerializeField] protected Transform _aimController;

    private GameObject _player;
        
    private bool _isAttacking;
    private Coroutine _attackCoroutine = null;

    public virtual void Init(GameObject pPlayer)
    {   
        _player = pPlayer;
    }

    private void OnEnable() 
    {
        _health = _maxHealth;

        if(_movement == null)
        {
            _movement = GetComponent<EnemyMovement>();
        }

        if (_detectionRadius == 0f)
        {
            _detectionRadius = _range + DETECTION_BASE;
        }

        _player = GameObject.Find("Player");
        Transform target = _player.transform; // get player
        _movement.Init(_range, _detectionRadius, _moveSpeed, target);

        _movement.WhenInRange += StartAttacking;
        _movement.WhenFollow += StopAttacking;
    }

    private void OnDisable()
    {
        _movement.WhenInRange -= StartAttacking;
        _movement.WhenFollow -= StopAttacking;
    }

    private void Update()
    {
        Vector3 rotation = _player.transform.position - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        _aimController.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    public virtual void ReduceHealth(int pDamage)
    {
        _health -= pDamage;

        if(_health <= 0)
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
        if(_attackCoroutine != null)
        {
            StopCoroutine(_attackCoroutine);
        }
        _attackCoroutine = StartCoroutine(I_Attacking());
    }

    private void StopAttacking()
    {
        Debug.Log("following");
        _isAttacking = false;
        if(_attackCoroutine != null)
        {
            StopCoroutine(_attackCoroutine);
        }
    }

    private IEnumerator I_Attacking()
    {
        float time = 0f;

        while (time <= _attackSpeed)
        {
            yield return new WaitForEndOfFrame();

            time += Time.deltaTime;
        }

        if (_isAttacking)
        {
            Attack();
            _attackCoroutine = StartCoroutine(I_Attacking());
        }
    }

    public virtual void Attack()
    {
        Debug.Log("attack: " + _isAttacking);

        _attackAbility.ActivateAbility(this.gameObject, _aimController);
    }
}