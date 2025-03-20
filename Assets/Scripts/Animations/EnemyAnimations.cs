using UnityEngine;

public class EnemyAnimations : Animations
{
    private readonly string _isAttack = "IsAttack";
    private bool _isAttackAnimationPlay;
    private void EnemyAttackAnimation()
    {
        
        _animator.SetBool(_isAttack,_isAttackAnimationPlay);
    }
}
