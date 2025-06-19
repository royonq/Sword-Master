using UnityEngine;

public class SatelliteSwordAttack : UltimateAttack
{
    [SerializeField] private Transform _playerPositionTracker;

    protected override void InitProjectileAbility(GameObject instancedAbility, ProjectileStats stats)
    {
        instancedAbility.transform.parent = _playerPositionTracker;
        base.InitProjectileAbility(instancedAbility, stats);
    }
}
