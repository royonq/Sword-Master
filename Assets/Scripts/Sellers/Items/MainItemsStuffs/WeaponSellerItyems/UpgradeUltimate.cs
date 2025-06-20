using UnityEngine;
[CreateAssetMenu(fileName = "NewTradeableItem", menuName = "Data/SellersItems/Ability/UpgradeUltimate")]
public class UpgradeUltimate : ItemsData
{
    public override void ApplyItem(PlayerModifiers playerModifiers)
    {
        playerModifiers.GetComponentInChildren<UltimateAttack>().UpgradeAbility(this);
    }
}
