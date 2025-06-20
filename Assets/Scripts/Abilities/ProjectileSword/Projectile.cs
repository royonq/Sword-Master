using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected float _speed;
    protected float _damage;
    protected float _lifeTime;
    protected bool _isUpgraded;
    
    protected Collider2D _attachedMobCollider;

    public virtual void Init(float damage, float speed, float lifeTime, bool isUpgraded, float damageModifier,
        Collider2D attachedMobCollider)
    {
        _damage = damage * damageModifier;
        _speed = speed;
        _lifeTime = lifeTime;
        _isUpgraded = isUpgraded;

        Destroy(gameObject, _lifeTime);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            _attachedMobCollider = collision;
            collision.GetComponent<Mob>().TakeDamage(_damage);
            Dispose();
        }
    }

    protected virtual void Dispose()
    {
        Destroy(gameObject);
    }
}