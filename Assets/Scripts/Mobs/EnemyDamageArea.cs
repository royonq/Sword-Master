using System.Collections;
using UnityEngine;

public class EnemyDamageArea : MonoBehaviour , IAttack
{
    private Collider2D _collider2D;
    private float _damage;

    private void OnEnable()
    {
        Enemy.OnInitDamage += Init;
    }

    private void OnDisable()
    {
        Enemy.OnInitDamage -= Init;
    }

    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    private void Init(float damage)
    {
        _damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Gate"))
        {
            other.GetComponent<Damageable>().TakeDamage(_damage);
        }
    }

    public IEnumerator Attack()
    {
        _collider2D.enabled = true;
        yield return null;
        _collider2D.enabled = false;
    }
}
