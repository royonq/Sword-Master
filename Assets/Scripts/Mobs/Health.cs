using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health;
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
