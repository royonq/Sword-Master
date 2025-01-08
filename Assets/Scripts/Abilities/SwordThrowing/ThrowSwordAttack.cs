using UnityEngine;

public class ThrowSwordAttack : Ability
{
    protected override void InitAbility(GameObject instancedAbility)
    {
        instancedAbility.GetComponent<SwordProjectile>().Init(_lifetime);
    }
}
