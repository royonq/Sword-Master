using System;
using System.Collections;
using UnityEngine;

public  class Enemy : Mob
{
    public static event Action OnDeath;
    public static event Action<int> OnDropMoney;

    [SerializeField] private EnemyMobAnimations _enemyMobAnimations;
    private IAttack _attack;
    private Transform _target;
    private EnemyStats _enemyStats;

    private Vector2 _direction;
    public Vector2 Direction => _direction;
    private float _killExpirience;
    private int _dropMoney;
    private bool _isAttacking;
    private float _stopDistance;
    
    protected override void SetStats()
    {
        base.SetStats();

        _enemyStats = _damagableStats as EnemyStats;
        
        _stopDistance = _enemyStats.AttackDistance;
        _killExpirience = _enemyStats.KillExpirience;
        _dropMoney = _enemyStats.MoneyToDrop;
        
        _attack = GetComponentInChildren<IAttack>();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
    
    private void FixedUpdate()
    {
        _direction = _target.position - transform.position;
        if (Vector2.Distance(transform.position, _target.position) > _stopDistance)
        {
            Move(_direction.normalized);
        }
        else
        {
            if (_isAttacking)
            {
                return;
            }
            Move(Vector2.zero);
            StartCoroutine(Attack(_target.gameObject));
        }
    }

    private IEnumerator Attack(GameObject target)
    {
        _isAttacking = true;

        yield return StartCoroutine(_enemyMobAnimations.EnemyAttackAnimation());
        yield return StartCoroutine(_attack.Attack());
        _isAttacking = false;
    }

    protected override void Die()
    {
        OnDropMoney?.Invoke(_dropMoney);
        OnDeath?.Invoke();
        Destroy(gameObject);
    }


    public void FindPlayer()
    {

    }

    public void Follow()
    {

    }

    public void DropXP()
    {

    }
}
