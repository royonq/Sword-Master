using System.Collections;
using UnityEngine;

public class SplitProjectile : SwordProjectile
{
  [SerializeField] private ProjectileAfterHitStats _hitProjectileStats;
  
  private readonly float _ignoreTime = 0.5f;
  private Collider2D _ignoreCollider;
  
  public override void Init(in ProjectileAbility.ProjectileStates  state, float damageModifier = 1f)
  {
    _states = state;
    _damage = _hitProjectileStats.Damage;
    _speed = _hitProjectileStats.Speed;
    _lifeTime = _hitProjectileStats.Lifetime;
    LaunchProjectile();
    Destroy(gameObject, _lifeTime);
  }

  public void SetIgnoreCollider(Collider2D collider)
  {
    _ignoreCollider = collider;
    StartCoroutine(ResetIgnoreCollision());
  }
  private IEnumerator ResetIgnoreCollision()
  {
    yield return new WaitForSeconds(_ignoreTime);
    _ignoreCollider = null;
  }
  
  protected override void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy") && _ignoreCollider!=collision)
    {
      base.OnTriggerEnter2D(collision);
    }
  }
}
