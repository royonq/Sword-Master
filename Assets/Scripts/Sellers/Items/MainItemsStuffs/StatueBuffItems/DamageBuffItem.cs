using UnityEngine;

[CreateAssetMenu(fileName = "NewTradebleItem", menuName = "Data/BuffItems/DamageBuffer")]
public class DamageBuffItem : ItemsData
{
    [SerializeField] private float _upgradeDamage;

    public override void ApplyItem(PlayerModifiers playerModifiers)
    {
        playerModifiers.DamageUpgrade = _upgradeDamage;
    }
}