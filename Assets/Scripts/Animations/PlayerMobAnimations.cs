using System.Collections;
using UnityEngine;

public class PlayerMobAnimations : MobAnimations
{
    private readonly string _deafultAttackAnimation = "IsAttack";
    private readonly string _ultimaAttackAnimation = "IsUltimate";
    private bool _isAbilityAnimationPlay;

    public IEnumerator PlayerAbilityAnimation(bool isUltimate)
    {
        _isAbilityAnimationPlay = true;
        var attackAnimation = isUltimate ? _ultimaAttackAnimation : _deafultAttackAnimation;

        _animator.SetBool(attackAnimation, true);
        
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        
        _animator.SetBool(attackAnimation, false);
        _isAbilityAnimationPlay = false;
    }
    
}