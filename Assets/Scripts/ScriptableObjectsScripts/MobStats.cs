using UnityEngine;

public abstract class MobStats : DamagebleStats
{
    [SerializeField] protected float _movementSpeed;
    public float MovementSpeed => _movementSpeed;


    [SerializeField] protected float _damage;
    public float Damage => _damage;
    
    
    [SerializeField] private SoundType _takeDamageSound;
    public SoundType TakeDamageSound => _takeDamageSound;
}