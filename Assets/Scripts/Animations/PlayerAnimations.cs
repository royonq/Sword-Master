using System.Collections;
using UnityEngine;

public class PlayerAnimations : Animations
{
    private readonly string _deafultAttackAnimation = "IsAttack";
    private readonly string _ultimaAttackAnimation = "IsUltimate";
    public bool isAnimationPlay;
    public bool IsAnimationPlay => isAnimationPlay;

    public IEnumerator PlayerAbilityAnimation(bool isUltimate)
    {
        isAnimationPlay = true;
        var attackAnimation = isUltimate ? _ultimaAttackAnimation : _deafultAttackAnimation;

        _animator.SetBool(attackAnimation, true);
        
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        
        _animator.SetBool(attackAnimation, false);
        isAnimationPlay = false;
    }
    
}