using UnityEngine;

public class EnemyDamage : Mob
{
    private float _damage;
    public float Damage { set { _damage = value; } }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var _playerHealth = collision.gameObject.GetComponent<Health>();
            _playerHealth.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
