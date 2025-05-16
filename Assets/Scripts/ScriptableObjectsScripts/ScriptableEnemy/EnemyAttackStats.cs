using UnityEngine;

public abstract class EnemyAttackStats : ScriptableObject
{
    [SerializeField] private float _damage;
    public float Damage => _damage;
    
    [SerializeField] private SoundType _attackSound;
    public SoundType AttackSound => _attackSound;
}
