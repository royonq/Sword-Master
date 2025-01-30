using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected UnitStats _unitStats;
    private float _health;

    protected abstract void Die();
    protected virtual void SetStats()
    {
        _health = _unitStats.Health;
    }

    public void TakeDamage(float recivedDamage)
    {
        _health -= recivedDamage;
        if (_health <= 0)
        {
            Die();
        }
    }
}
