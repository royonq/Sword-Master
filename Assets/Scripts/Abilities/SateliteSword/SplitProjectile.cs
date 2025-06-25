using System;
using System.Collections;
using UnityEngine;

public class SplitProjectile : SwordProjectile
{
  private readonly float _ignoreTime = 0.5f;
  private Collider2D _ignoreCollider;
  public override void Init(ProjectileState stats, float damageModifier = 1f)
  {
    base.Init(stats, damageModifier);
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
