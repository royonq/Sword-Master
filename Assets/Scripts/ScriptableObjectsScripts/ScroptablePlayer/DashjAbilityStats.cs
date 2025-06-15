using UnityEngine;

[CreateAssetMenu(fileName = "NewAbility", menuName = "Data/Abilities/DashAbilityStats")]
public class DashAbilityStats : AbilityStats
{
    [SerializeField] private float _force;
    public float Force => _force;
    
    [SerializeField] private float _slowCoefficient;
    public float SlowCoefficient => _slowCoefficient;
    [SerializeField] private float _slowDuration;
    public float SlowDuration => _slowDuration;
    
    [SerializeField] private float _slowRadius;
    public float SlowRadius => _slowRadius;
}
