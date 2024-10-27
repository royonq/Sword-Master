using UnityEngine;
[CreateAssetMenu(fileName = "SatilateSword",menuName = "Abilities")]
public class AbilitySateliteSword : ScriptableObject
{
    [SerializeField] private float _damage;
    public float Damage {get { return _damage;}}
    [SerializeField] private float _rotationSpeed;
    public float RotationSpeed { get { return _rotationSpeed;}}
    [SerializeField] private float _timeCooldown;
    public float TimeCooldown { get { return _timeCooldown;}}
    [SerializeField] private Sprite _abilityIcon;
    public Sprite AbilityIcon { get { return _abilityIcon; } }
    [SerializeField] private Sprite _abilityCooldownIcon;
    public Sprite AbilityCooldownIcon { get { return _abilityCooldownIcon; } }
}
