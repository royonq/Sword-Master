using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected float _speed;
    private float _damage;
    private float _lifeTime;

    public virtual void Init(float damage, float speed, float lifeTime, PlayerModifiers modifiers)
    {
        _damage = damage * modifiers.DamageModifier;
        _speed = speed;
        _lifeTime = lifeTime;

        Destroy(gameObject, _lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collision.GetComponent<Mob>().TakeDamage(_damage);

            Destroy(gameObject);
        }
    }
}