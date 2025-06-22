using UnityEngine;

public class SatelliteSword : Projectile
{
    [SerializeField] private GameObject _satellitePrefab;
    [SerializeField] private ProjectileAfterHitStats _hitProjectileStats;
    
    private void FixedUpdate()
    {
        RotateAroundPlayer();
    }
    
    private void RotateAroundPlayer()
    {
        transform.Rotate(_speed * Time.fixedDeltaTime * Vector3.forward);
    }
    
    protected override void Dispose(Collider2D mobCollider)
    {
        if (!_isUpgraded || mobCollider == null)
        {
         
            base.Dispose(mobCollider);
            return;
        }
        
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
            afterHit.Init(_hitProjectileStats.Damage, _hitProjectileStats.Speed, _hitProjectileStats.Lifetime, _isUpgraded, 1);
            afterHit.SetIgnoreCollider(mobCollider);
        }
        base.Dispose(mobCollider);
    }
}
