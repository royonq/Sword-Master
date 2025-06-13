using UnityEngine;

[CreateAssetMenu(fileName = "NewTradeableItem", menuName = "Data/SellersItems/Ability/UpgradeDashAbility")]
public class UpgradeDashAbility : ItemsData
{
    [SerializeField] private float _increaseSlowDuration;
    public float IncreaseSlowDuration => _increaseSlowDuration;
    
    [SerializeField] private float _increaseSlowCoefficient;
    public float IncreaseSlowCoefficient => _increaseSlowCoefficient;
    
    [SerializeField] private float _increaseSlowRadius;
    public float IncreaseSlowRadius => _increaseSlowRadius;
    
    [SerializeField] private float _increaseDistance; 
    public float IncreaseDistance => _increaseDistance;
    public override void ApplyItem(PlayerModifiers playerModifiers)
    {
        playerModifiers.GetComponentInChildren<DashAbility>().UpgradeAbility(this);
    }
}
