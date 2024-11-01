using UnityEngine;

public class Health : MonoBehaviour
{
    private float _health;
    public float CurrentHealth { set { _health = value; } }
    public void TakeDamage(float recivedDamage)
    {
        _health -= recivedDamage;
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
