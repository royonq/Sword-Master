using UnityEngine;

public class Sword : MonoBehaviour
{
    private SwordAbilityManager _swordAbilityManager;
    private float _damage;
    private void Start()
    {
        _swordAbilityManager = GetComponentInParent<SwordAbilityManager>();
        _damage = _swordAbilityManager.Damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            var enemyhealth = collision.GetComponent<Health>();
            enemyhealth.TakeDamage(_damage);
        }
    }
}
