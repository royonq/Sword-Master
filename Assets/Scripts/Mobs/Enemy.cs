using UnityEngine;

public class Enemy : Mob
{
    [SerializeField] private EnemyStats _enemyStats;
    private float _killExpirience;
    private void Start()
    {
        SetStats(_enemyStats);
    }
    protected override void SetStats(MobStats mobStats)
    {
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
