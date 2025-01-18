using UnityEngine;

public class SwordProjectile : Sword
{
    private Rigidbody2D _rb;

    public override void Init(AbilityStats stats)
    {
        var _swordProjectileStats = stats as SwordProjectileStats;
        base.Init(_swordProjectileStats);

        LaunchProjectile();
    }

    private void LaunchProjectile()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = _speed * transform.right;

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
