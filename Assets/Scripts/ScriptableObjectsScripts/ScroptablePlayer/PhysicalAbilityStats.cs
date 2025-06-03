using UnityEngine;

public abstract class PhysicalAbilityStats : AbilityStats
{
    [SerializeField] private float _damage;

    public float Damage => _damage;

    [SerializeField] private float _lifetime;
    public float Lifetime => _lifetime;

    [SerializeField] private float _speed;
    public float Speed => _speed;

 
}