using UnityEngine;

public class ProjectileAfterHit : SwordProjectile
{
  [SerializeField] private ProjectileAfterHitStats _hitProjectileStats;
  public override void Init(float damage, float speed, float lifeTime, bool isUpgraded, float damageModifier, Collider2D attachedMobCollider)
  {
    base.Init(_hitProjectileStats.Damage, _hitProjectileStats.Speed, _hitProjectileStats.Lifetime, isUpgraded, damageModifier, attachedMobCollider);
    Physics2D.IgnoreCollision(GetComponent<Collider2D>(), _attachedMobCollider);
    LaunchProjectile();
  }
}
