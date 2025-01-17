using UnityEngine;

public class SatelliteSwordAttack : Ability
{
    [SerializeField] private Transform _playerPositionTracker;
    protected override void InitAbility(GameObject instancedAbility, AbilityStats stats)
    {
        var sateliteSwordStats = stats as SateliteSwordStats;
        instancedAbility.transform.parent = _playerPositionTracker;
        instancedAbility.GetComponent<SatelliteSword>().Init(sateliteSwordStats);
    }
}
