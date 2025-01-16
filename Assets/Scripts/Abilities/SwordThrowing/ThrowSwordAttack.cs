using UnityEngine;

public class ThrowSwordAttack : Ability
{
    protected override void InitAbility(GameObject instancedAbility, AbilityStats stats)
    {
        var swordProjectileStats = stats as SwordProjectileStats;
        SetImage(swordProjectileStats.AbilityIcon);
        instancedAbility.GetComponent<SwordProjectile>().Init(swordProjectileStats);
    }
}
