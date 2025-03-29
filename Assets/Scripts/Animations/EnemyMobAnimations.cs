using System.Collections;
using UnityEngine;

public class EnemyMobAnimations : MobAnimations
{
    [SerializeField] private Transform _weaponCollider;
    private readonly string _enemyAttackAnimation = "IsAttack";

    public IEnumerator EnemyAttackAnimation()
    {
        _animator.SetBool(_enemyAttackAnimation, true);

        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);

        _animator.SetBool(_enemyAttackAnimation, false);
    }

    public override void MoveIdleAnimation(Vector2 direction)
    {
        base.MoveIdleAnimation(direction);
        
       _weaponCollider.GetComponent<EnemyDamageArea>().FlipDamageArea(_spriteRenderer);
    }
}