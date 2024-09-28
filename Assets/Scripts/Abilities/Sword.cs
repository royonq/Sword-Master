using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private float _damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            var enemyhealth = collision.GetComponent<EnemyHealth>();
            enemyhealth.TakeDamage(_damage);
        }
    }
}
