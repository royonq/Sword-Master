using UnityEngine;

public class ProjectileAfterHit : SwordProjectile
{
  [SerializeField] private ProjectileAfterHitStats _hitProjectileStats;
  public override void Init(float damage, float speed, float lifeTime, bool isUpgraded, float damageModifier, Collider2D attachedMobCollider)
  {
    _damage = _hitProjectileStats.Damage * damageModifier;
    _speed = _hitProjectileStats.Speed;
    _lifeTime = _hitProjectileStats.Lifetime;
    _isUpgraded = isUpgraded;
    _attachedMobCollider = attachedMobCollider;
    
    Physics2D.IgnoreCollision(GetComponent<Collider2D>(), attachedMobCollider);
    LaunchProjectile();
  }
}
