using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected float _speed;
    private float _damage;
    private float _lifeTime;

    public virtual void Init(AbilityStats stats)
    {
        _damage = stats.Damage;
        _speed = stats.Speed;
        _lifeTime = stats.Lifetime;

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
