using UnityEngine;

[CreateAssetMenu(fileName = "NewTradebleItem", menuName = "Data/BuffItems/HealthBuffer")]
public class HealthBuffItem : ItemsData
{
    [SerializeField] private float _upgradeHealth;

    public override void ApplyItem(PlayerModifiers playerModifiers)
    {
        playerModifiers.HealthUpgrade = _upgradeHealth;
        
        playerModifiers.GetComponent<Player>().UpgradeMaxHealth(playerModifiers.HealthModifier);
    }
}
