using UnityEngine;

public class SwordProjectile : Projectile
{
    private Rigidbody2D _rb;
    
    protected void LaunchProjectile()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = _speed * transform.right;
    }
}