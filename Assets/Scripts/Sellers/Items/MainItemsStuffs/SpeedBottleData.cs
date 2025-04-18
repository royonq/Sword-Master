using UnityEngine;


[CreateAssetMenu(fileName = "NewTradebleItem", menuName = "Data/SellersItems/SpeedBottle")]
public class SpeedBottleData : ItemsData
{
    [SerializeField] private float _upgradeSpeed;
    public float UpgradeSpeed => _upgradeSpeed / 100;
}