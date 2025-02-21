using UnityEngine;
using UnityEngine.InputSystem;

public class SwordProjectile : ProjectileRotate
{
    private Rigidbody2D _rb;
    public override void Init(AbilityStats stats)
    {
        base.Init(stats);
        RotateTowardsCrosshair();
        LaunchProjectile();

    }

    private void LaunchProjectile()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = _speed * transform.right;
    }
}
