using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    [SerializeField] protected DamagebleStats _damagableStats;
    protected float _health;

    protected abstract void Die();
    protected virtual void SetStats()
    {
        _health = _damagableStats.Health;
    }
    
    public virtual void TakeDamage(float recivedDamage)
    {
        _health -= recivedDamage;
        if (_health <= 0)
        {
            Die();
        }
    }
}
