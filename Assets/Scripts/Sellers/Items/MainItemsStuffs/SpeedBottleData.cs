using UnityEngine;


[CreateAssetMenu(fileName = "NewTradebleItem", menuName = "Data/SellersItems/SpeedBottle")]
public class SpeedBottleData : ItemsData
{
    [SerializeField] private float _upgradeSpeed;
    public override void ApplyItem(PlayerModifiers playerModifiers)
    {
        playerModifiers.SpeedUpgrade =_upgradeSpeed;
    }
}