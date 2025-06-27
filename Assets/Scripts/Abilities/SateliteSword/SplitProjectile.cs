using System.Collections;
using UnityEngine;

public class SplitProjectile : SwordProjectile
{
  private readonly float _ignoreTime = 0.5f;
  private Collider2D _ignoreCollider;

  public void Init(in ProjectileAfterHitStats.SplitStats state, float damageModifier = 1f)
  {
    _damage = state.InitDamage * damageModifier;
    _speed = state.InitSpeed;
    _lifeTime = state.InitLifetime;

    Destroy(gameObject, _lifeTime);
    LaunchProjectile();
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
