using UnityEngine;
[CreateAssetMenu(fileName = "NewFamiliarAbility", menuName = "Data/FamiliarAbility/Autoatack")]
public class FamiliarAutoatackData : ScriptableObject
{
    [SerializeField] private float _damage; 
    public float Damage => _damage;
    
    [SerializeField] private float _abilityRadius;
    public float AbilityRadius => _abilityRadius;
}
