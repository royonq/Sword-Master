using UnityEngine;


[CreateAssetMenu(fileName = "NewTradebleItem", menuName = "Data/BuffItems/SpeedBuffer")]
public class SpeedBuffItem : ItemsData
{
    [SerializeField] private float _upgradeSpeed;

    public override void ApplyItem(PlayerModifiers playerModifiers)
    {
        playerModifiers.SpeedUpgrade = _upgradeSpeed;
    }
}