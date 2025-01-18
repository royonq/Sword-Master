using UnityEngine;

public class SwordProjectile : Projectile
{
    private Rigidbody2D _rb;

    public override void Init(AbilityStats stats)
    {
        base.Init(stats);
        LaunchProjectile();
    }

    private void LaunchProjectile()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = _speed * transform.right;
    }
}
