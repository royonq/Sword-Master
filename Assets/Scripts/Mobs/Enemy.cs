using System;
using System.Collections;
using UnityEngine;

public class Enemy : Mob
{
    public static event Action OnDeath;
    public static event Action<int> OnDropMoney; 
    
    [SerializeField] private EnemyMobAnimations _enemyMobAnimations;
    
    private Transform _target;
    public Transform Target { set => _target = value; }
    private Vector2 _direction;
    private float _killExpirience;
    private int _dropMoney;
    private bool _isAttacking;
    protected override void SetStats()
    {
        base.SetStats();

        var enemyStats = _damagableStats as EnemyStats;

        _killExpirience = enemyStats.KillExpirience;
        _dropMoney = enemyStats.MoneyToDrop;
    }

    private void FixedUpdate()
    {
        _direction = _target.position - transform.position;
        if (Vector2.Distance(transform.position, _target.position) > 2)
        {
            Move(_direction.normalized);
        }
        else
        {
            if (!_isAttacking)
            {
                Move(Vector2.zero);
                StartCoroutine(Attack(_target.gameObject));
            }
        }
    }

    private IEnumerator Attack(GameObject target)
    {
        _isAttacking = true;
        
        yield return StartCoroutine(_enemyMobAnimations.EnemyAttackAnimation());

        target.GetComponent<Damageable>().TakeDamage(_damage);

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
