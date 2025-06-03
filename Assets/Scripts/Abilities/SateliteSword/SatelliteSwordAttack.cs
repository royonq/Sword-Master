using UnityEngine;

public class SatelliteSwordAttack : UltimateAttack
{
    [SerializeField] private Transform _playerPositionTracker;
    protected override void InitProjectileAbility(GameObject instancedAbility, AbilityStats stats)
    {
        instancedAbility.transform.parent = _playerPositionTracker;
        base.InitProjectileAbility(instancedAbility, stats);
    }
}
