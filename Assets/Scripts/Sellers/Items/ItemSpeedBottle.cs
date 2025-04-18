public class ItemSpeedBottle : Item
{
    protected override void ApplyItem()
    {
        var playerModifires = GetModifier();
        var speedBottleData = _itemsData as SpeedBottleData;
        playerModifires.SpeedUpgrade = speedBottleData.UpgradeSpeed;
    }
}