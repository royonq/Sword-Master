using UnityEngine;

public class InitializeEnemyStats : MonoBehaviour
{
    [SerializeField] EnemyStats _enemyStats;
    private EnemyDamage _damage;
    private FollowTarget _followTarget;

    private void Start()
    {
        GetComponents();
        SetStats();
    }

    private void GetComponents()
    {
        _damage = GetComponent<EnemyDamage>();
        _followTarget = GetComponent<FollowTarget>();
    }
    private void SetStats()
    {
        _damage.Damage = _enemyStats.Damage;
        _followTarget.Speed = _enemyStats.Speed;
    }

}
