using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    [SerializeField] protected DamagebleStats _damagableStats;
    protected float _maxHealth;
    protected float _currentHealth;

    private void Start()
    {
        SetStats();
    }

    protected abstract void Die();
    protected virtual void SetStats()
    {
        _maxHealth = _damagableStats.MaxHealth;
        _currentHealth = _maxHealth;
    }
    
    public virtual void TakeDamage(float recivedDamage)
    {
        _currentHealth -= recivedDamage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }
}
