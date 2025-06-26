using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected float _speed;
    private float _damage;
    private float _lifeTime;
    protected bool _isUpgraded;
    
    public virtual void Init(ProjectileState state, float damageModifier = 1f)
    {
        _damage = state.Damage * damageModifier;
        _speed = state.Speed;
        _lifeTime = state.LifeTime;
        _isUpgraded = state.IsUpgraded;

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