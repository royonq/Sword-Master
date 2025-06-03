using UnityEngine;

[CreateAssetMenu(fileName = "NewAbility", menuName = "Data/Abilities/DashAbilityStats")]
public class DashAbilityStats : AbilityStats
{
    [SerializeField] private float _distance;
    public float Distance => _distance;
    
    [SerializeField] private float _duration;
    public float Duration => _duration;
}
