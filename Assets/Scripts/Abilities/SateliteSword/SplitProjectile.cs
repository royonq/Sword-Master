using System.Collections;
using UnityEngine;

public class SplitProjectile : SwordProjectile
{
  private readonly float _ignoreTime = 0.5f;
  private Collider2D _ignoreCollider;

  public void Init(in IProjectileState state, float damageModifier = 1f)
  {
    base.Init(state, damageModifier);
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
  public readonly struct SplitStats : IProjectileState
  {
    private readonly ProjectileAfterHitStats _projectile;
    public float Damage => _projectile.Damage;
    public float Speed => _projectile.Speed;
    public float LifeTime => _projectile.Lifetime;
    public bool IsUpgraded => false;
    public SplitStats(ProjectileAfterHitStats projectile)
    {
      _projectile = projectile;
    }
  }
}
