using System;
using UnityEngine;

public class SatelliteSword : Projectile
{
    [SerializeField] private GameObject _satellitePrefab;
    [SerializeField] private ProjectileAfterHitStats _hitProjectileStats;
    private ProjectileState _state; 

    private void Awake()
    {
        _state = new ProjectileState
        {
            Damage = _hitProjectileStats.Damage,
            Speed = _hitProjectileStats.Speed,
            LifeTime = _hitProjectileStats.Lifetime,
            IsUpgraded = _hitProjectileStats
        };
    }

    private void FixedUpdate()
    {
        RotateAroundPlayer();
    }
    
    private void RotateAroundPlayer()
    {
        transform.Rotate(_speed * Time.fixedDeltaTime * Vector3.forward);
    }
    
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (!_isUpgraded)
            {
                base.OnTriggerEnter2D(collision);
                return;
            }
        
            SplitProjectile(collision);
            base.OnTriggerEnter2D(collision);
        }
    }

    private void SplitProjectile(Collider2D mobCollider)
    {
        float baseAngle = mobCollider.transform.localScale.x < 0 ? 0f : 180f;

        for (int angle = -45; angle <= 45; angle += 45)
        {
            float finalAngle = baseAngle + angle;
            var rotation = Quaternion.Euler(0, 0, finalAngle);
            var instancedProjectile = Instantiate(
                _satellitePrefab,
                mobCollider.transform.position,
                rotation
            );
            var afterHit = instancedProjectile.GetComponent<SplitProjectile>();
            afterHit.Init(_state);
            afterHit.SetIgnoreCollider(mobCollider);
        }
    }
}
