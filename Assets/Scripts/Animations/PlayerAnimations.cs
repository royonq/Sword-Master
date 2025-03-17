using System.Collections;
using UnityEngine;

public class PlayerAnimations : Animations
{
    private readonly string _deafultAttackAnimation = "IsAttack";
    private readonly string _ultimaAttackAnimation = "IsUltimate";


    public IEnumerator PlayerAbilityAnimation(bool isUltimate,Ability ability)
    {
        var attackAnimation = isUltimate ? _ultimaAttackAnimation : _deafultAttackAnimation;

        _animator.SetBool(attackAnimation, true);
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        ability.InitInstanceAbility();
        _animator.SetBool(attackAnimation, false);
    }
}