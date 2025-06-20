using UnityEngine;

public class SwordProjectile : ProjectileRotate
{
    private Rigidbody2D _rb;

    public override void Init(float damage, float speed, float lifeTime, bool isUpgraded, float damageModofier, Collider2D attachedMobCollider)
    {
        base.Init(damage, speed, lifeTime,isUpgraded, damageModofier, attachedMobCollider);
        LaunchProjectile();
    }

    protected void LaunchProjectile()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = _speed * transform.right;
    }
}