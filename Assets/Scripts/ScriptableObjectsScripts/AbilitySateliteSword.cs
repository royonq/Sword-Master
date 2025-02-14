using UnityEngine;

[CreateAssetMenu(fileName = "NewAbility",menuName = "Data/Abilities")]
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
}
