using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected float _speed;
    private float _damage;
    private float _lifeTime;
    protected bool _isUpgraded;
    
    public virtual void Init(float damage, float speed, float lifeTime, bool isUpgraded, float damageModifier = 1f)
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
            collision.GetComponent<Mob>().TakeDamage(_damage);
            Dispose();
        }
    }

    protected  void Dispose()
    {
        Destroy(gameObject);
    }
}