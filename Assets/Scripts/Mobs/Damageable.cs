using System;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    [SerializeField] protected DamagebleStats _damageableStats;
    private float _maxHealth;
    protected virtual float ModifierHealth => _maxHealth;

    protected float _currentHealth;
    protected virtual bool PlayOneShot => false;

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
        SoundCaller.PlaySound (_damageableStats.TakeDamageSound,PlayOneShot);
        if (_currentHealth <= 0)
        {
            Die();
        }
    }
}