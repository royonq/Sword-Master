using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : Mob
{
    private Transform _target;
    public Transform Target { set { _target = value; } }
    private float _killExpirience;
    protected override void SetStats()
    {
        base.SetStats();

        EnemyStats enemyStats = _mobStats as EnemyStats;

        _killExpirience = enemyStats.KillExpirience;
    }

    private void FixedUpdate()
    {
        Move((_target.position - transform.position).normalized);
    }

    public void DropXP()
    {

    }
}
