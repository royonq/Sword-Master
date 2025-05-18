using System;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    protected Action<SoundType> OnTakeDamage;
    [SerializeField] protected DamagebleStats _damageableStats;
    private float _maxHealth;
    protected virtual float ModifierHealth => _maxHealth;

    protected float _currentHealth;

    private void Start()
    {
        SetStats();
    }

    protected abstract void Die();

    protected virtual void SetStats()
    {
        _maxHealth = _damageableStats.MaxHealth;
        _currentHealth = _maxHealth;
    }

    public virtual void TakeDamage(float recivedDamage)
    {
        _currentHealth -= recivedDamage;
        OnTakeDamage?.Invoke(_damageableStats.TakeDamageSound);
        if (_currentHealth <= 0)
        {
            Die();
        }
    }
}