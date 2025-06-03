using UnityEngine;

public class SwordProjectile : ProjectileRotate
{
    private Rigidbody2D _rb;

    public override void Init(PhysicalAbilityStats stats, PlayerModifiers modifiers)
    {
        base.Init(stats, modifiers);
        LaunchProjectile();
    }

    private void LaunchProjectile()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = _speed * transform.right;
    }
}