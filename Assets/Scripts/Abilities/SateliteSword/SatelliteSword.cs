using System;
using UnityEngine;

public class SatelliteSword : Projectile
{
    [SerializeField] private GameObject _satellitePrefab;
    private void FixedUpdate()
    {
        RotateAroundPlayer();
    }
    
    private void RotateAroundPlayer()
    {
        transform.Rotate(_speed * Time.fixedDeltaTime * Vector3.forward);
    }
    
    protected override void Dispose()
    {
        if (!_isUpgraded)
        {
            base.Dispose();
            return;
        }
        
        for (int angle = -45; angle <= 45; angle += 45)
        {
          var instancedProjectile =  Instantiate(_satellitePrefab, transform.position, Quaternion.Euler(0, 0, angle));
          instancedProjectile.GetComponent<ProjectileAfterHit>().Init(
              _damage,
              _speed,
              _lifeTime,
              _isUpgraded,
              1,
              _attachedMobCollider
          );
        }

        base.Dispose();
    }
}
