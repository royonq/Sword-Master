using UnityEngine;

public abstract class AbilityStats : ScriptableObject
{
    [SerializeField] private float _damage;

    public float Damage => _damage;

    [SerializeField] private float _lifetime;
    public float Lifetime => _lifetime;

    [SerializeField] private float _speed;
    public float Speed => _speed;

    [SerializeField] protected float _cooldown;
    public float Cooldown => _cooldown;

    [SerializeField] private Sprite _abilityIcon;
    public Sprite AbilityIcon => _abilityIcon;
}