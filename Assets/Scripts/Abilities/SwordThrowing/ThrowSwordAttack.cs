using System.Collections;
using UnityEngine;
using Color = UnityEngine.Color;

public class ThrowSwordAttack : ProjectileAbility
{
    public override void UpgradeAbility(ItemsData itemData)
    {
        base.UpgradeAbility(itemData);
        var data = itemData as UpgradeSrowSwordAttack;
        
        _damageModifier += data.IncreaseDamage;
        _speedModifier += data.IncreaseSpeed;
        _cooldownModifier += data.IncreaseCooldown;
        
        _abilityImage.color = Color.gray;
    }
    
    protected override void EnableAbility()
    {
        base.EnableAbility();
        if (_isAbilityUpgraded)
        {
            StartCoroutine(AutoUse());
        }
    }
    
    
    protected override void DisableAbility()
    {
        base.DisableAbility();
        StopCoroutine(AutoUse());
    }
    
    
    private IEnumerator AutoUse()
    {
        while (_canUseAbility)
        {
            base.Use();
            var cooldown = _projectileStats.Cooldown - _cooldownModifier;
            yield return new WaitForSeconds(cooldown);
        }
    }
    
    public override void Use()
    {
        if (!_canUseAbility)
        {
            return;
        }

        if (_isAbilityUpgraded)
        {
            OnTryUseAutoAbility?.Invoke();
            return;
        }
     
        base.Use();
    }
}
