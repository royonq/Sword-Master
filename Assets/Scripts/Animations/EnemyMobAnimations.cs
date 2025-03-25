using System.Collections;
using UnityEngine;

public class EnemyMobAnimations : MobAnimations
{
    private readonly string _enemyAttackAnimation = "IsAttack";

    public IEnumerator EnemyAttackAnimation()
    {
        _animator.SetBool(_enemyAttackAnimation, true);

        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        
        _animator.SetBool(_enemyAttackAnimation, false);
    }
}