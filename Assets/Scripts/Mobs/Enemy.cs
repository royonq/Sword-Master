using UnityEngine;

public class Enemy : Mob
{

    private float _killExpirience;
    protected override void SetStats()
    {
        base.SetStats();

        EnemyStats enemyStats = _mobStats as EnemyStats;

        _killExpirience = enemyStats.KillExpirience;
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
