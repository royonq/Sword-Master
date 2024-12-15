using UnityEngine;

public class Enemy : Mob
{
    [SerializeField] private EnemyStats _enemyStats;
    private float _killExpirience;
    private void Start()
    {
        
    }
    protected override void SetStats(MobStats mobStats)
    {
        _enemyStats = mobStats as EnemyStats;

        base.SetStats(_enemyStats);

        _killExpirience = _enemyStats.KillExpirience;
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
