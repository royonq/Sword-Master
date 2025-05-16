using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    [SerializeField] protected DamagebleStats _damagableStats;
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
        _maxHealth = _damagableStats.MaxHealth;
        _currentHealth = _maxHealth;
    }

    public virtual void TakeDamage(float recivedDamage)
    {
        _currentHealth -= recivedDamage;
        SoundCaller.PlaySound(_damagableStats.TakeDamageSound);
        if (_currentHealth <= 0)
        {
            Die();
        }
    }
}