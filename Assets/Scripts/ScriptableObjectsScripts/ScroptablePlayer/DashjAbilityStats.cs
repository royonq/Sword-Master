using UnityEngine;

[CreateAssetMenu(fileName = "NewAbility", menuName = "Data/Abilities/DashAbilityStats")]
public class DashAbilityStats : AbilityStats
{
    [SerializeField] private float _distance;
    public float Distance => _distance;
    
    [SerializeField] private float _duration;
    public float Duration => _duration;
    
    [SerializeField] private float _slowFactor;
    public float SlowFactor => _slowFactor;
    [SerializeField] private float _slowDuration;
    public float SlowDuration => _slowDuration;
    
    [SerializeField] private float _slowRadius;
    public float SlowRadius => _slowRadius;
}
