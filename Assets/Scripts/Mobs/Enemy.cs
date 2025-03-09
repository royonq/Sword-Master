using System;
using UnityEngine;

public class Enemy : Mob
{
    public static event Action OnDeath;
    public static event Action<int> OnDropMoney;
    private Transform _target;
    public Transform Target { set { _target = value; } }
    private float _killExpirience;
    private int _dropMoney;
    protected override void SetStats()
    {
        base.SetStats();

        var enemyStats = _damagableStats as EnemyStats;

        _killExpirience = enemyStats.KillExpirience;
        _dropMoney =  enemyStats.MoneyToDrop;
    }
    private void FixedUpdate()
    {
        Move((_target.position - transform.position).normalized);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") || collision.gameObject.layer == LayerMask.NameToLayer("Gate"))
        {
            collision.gameObject.GetComponent<Damageable>().TakeDamage(_damage);
        }
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
