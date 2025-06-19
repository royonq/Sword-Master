using UnityEngine;

[CreateAssetMenu(fileName = "NewTradeableItem", menuName = "Data/SellersItems/Ability/UpgradeSrowSwordAttack")]
public class UpgradeSrowSwordAttack : ItemsData
{
    [SerializeField] private float _increaseDamage;

    public float IncreaseDamage => _increaseDamage;

    [SerializeField] private float _increaseSpeed;

    public float IncreaseSpeed => _increaseSpeed;
    
    [SerializeField] protected float _increaseCooldown;
    public float IncreaseCooldown => _increaseCooldown;
    
    public override void ApplyItem(PlayerModifiers playerModifiers)
    {
        playerModifiers.GetComponentInChildren<ThrowSwordAttack>().UpgradeAbility(this);
    }
}
