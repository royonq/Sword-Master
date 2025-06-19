using UnityEngine;

public class SwordProjectile : ProjectileRotate
{
    private Rigidbody2D _rb;

    public override void Init(float damage, float speed, float lifeTime, PlayerModifiers modifiers)
    {
        base.Init(damage, speed, lifeTime, modifiers);
        LaunchProjectile();
    }

    private void LaunchProjectile()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = _speed * transform.right;
    }
}