using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float _damage;

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
