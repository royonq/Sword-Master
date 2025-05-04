using UnityEngine;

[CreateAssetMenu(fileName = "NewFamiliar", menuName = "Data/Familiar")]
public class FamiliarStats : ScriptableObject
{
    [SerializeField] private float _familiarSpeed;
    public float FamiliarSpeed => _familiarSpeed;
    
    [SerializeField] private float _stopDistance;
    public float StopDistance => _stopDistance;

    [SerializeField] private float _stopSpeed;
    public float StopSpeed => _stopSpeed;

    [SerializeField] private float _abilityCooldown;
    public float AbilityCooldown => _abilityCooldown;
}
