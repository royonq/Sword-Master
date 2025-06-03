using UnityEngine;

[CreateAssetMenu(fileName = "NewAbility", menuName = "Data/Abilities/DashAbilityStats")]
public class DashAbilityStats : AbilityStats
{
    [SerializeField] private float _dashDistance;
    public float DashDistance => _dashDistance;

    [SerializeField] private float _dashDuration;
    public float DashDuration => _dashDuration;
}
