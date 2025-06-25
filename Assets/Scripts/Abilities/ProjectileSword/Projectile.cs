using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected float _speed;
    private float _damage;
    private float _lifeTime;
    protected bool _isUpgraded;
    
    public virtual void Init(ProjectileState stats, float damageModifier = 1f)
    {
        _damage = stats.Damage * damageModifier;
        _speed = stats.Speed;
        _lifeTime = stats.LifeTime;
        _isUpgraded = stats.IsUpgraded;

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

    private void Dispose()
    {
        Destroy(gameObject);
    }
}