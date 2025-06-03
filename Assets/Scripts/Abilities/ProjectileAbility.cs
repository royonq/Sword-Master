using UnityEngine;

public abstract class AbstractAbility : Ability
{
    [SerializeField] private Transform _spawnpoint;
    [SerializeField] private GameObject _ability;
    protected virtual void InitProjectileAbility(GameObject instancedAbility, AbilityStats stats)
    {
        var physicalStats = stats as ProjectileStats;
        instancedAbility.GetComponent<Projectile>().Init(physicalStats, _playerModifiers);
    }
    protected override void InitAbility()
    {
        var instancedAbility = Instantiate(_ability, _spawnpoint.position, Quaternion.identity);
        InitProjectileAbility(instancedAbility, _stats);
        base.InitAbility();
    }
}
