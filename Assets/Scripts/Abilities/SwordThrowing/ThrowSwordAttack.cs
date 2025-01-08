using UnityEngine;

public class ThrowSwordAttack : Ability
{
    [SerializeField] private float _swordLifeTime;

    protected override void InitAbility(GameObject instancedAbility)
    {
        instancedAbility.GetComponent<SwordProjectile>().Init(_swordLifeTime);
    }
}
