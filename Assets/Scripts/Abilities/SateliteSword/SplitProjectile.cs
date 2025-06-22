using System;
using System.Collections;
using UnityEngine;

public class SplitProjectile : SwordProjectile
{
  private readonly float _ignoreTime = 0.5f;
  private Collider2D _ignoreCollider;
  private Collider2D _projectilecollider;
  public override void Init(float damage, float speed, float lifeTime, bool isUpgraded, float damageModifier)
  {
    base.Init(damage, speed, lifeTime, isUpgraded, damageModifier);
    LaunchProjectile();
    _projectilecollider = GetComponent<Collider2D>();
  }

  public void SetIgnoreCollider(Collider2D collider)
  {
    _ignoreCollider = collider;
    Physics2D.IgnoreCollision(_projectilecollider, _ignoreCollider, true);
    StartCoroutine(ResetIgnoreCollision());
  }

  private IEnumerator ResetIgnoreCollision()
  {
    yield return new WaitForSeconds(_ignoreTime);
    if (_projectilecollider == null)
    {
      yield break;
    }
    Physics2D.IgnoreCollision(_projectilecollider, _ignoreCollider, false);
  }
}
