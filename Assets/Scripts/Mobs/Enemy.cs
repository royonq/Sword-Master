using UnityEngine;

public class Enemy : Mob
{
    [SerializeField] private MobStats _mobStats;

    private float _killExpirience;
    private void Start()
    {
        SetStats(_mobStats);
    }
    protected override void SetStats(MobStats mobStats)
    {
        base.SetStats(mobStats);

        EnemyStats enemyStats = mobStats as EnemyStats;

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
