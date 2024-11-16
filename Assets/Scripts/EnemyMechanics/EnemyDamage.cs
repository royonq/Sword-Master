using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private float _damage;
    public float Damage { set { _damage = value; } }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
