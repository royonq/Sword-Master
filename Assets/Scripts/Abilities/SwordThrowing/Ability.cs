using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Ability : MonoBehaviour
{

    [SerializeField] protected AbilityStats _stats;
    [SerializeField] private PlayerAnimations _playerAnimations;
    [SerializeField] protected PlayerModifiers _playerModifiers;

    [SerializeField] private Image _abilityColdownImage;
    [SerializeField] protected Image _abilityImage;
    
    private bool _isAbilityUsing;
    protected bool _isAbilityUpgraded;

    protected abstract void InitAbility();

    private void Start()
    {
        SetAbilityImage();
    }
    
    public virtual void UpgradeAbility(ItemsData itemData)
    {
        _isAbilityUpgraded = true;
    }

    private void SetAbilityImage()
    {
        _abilityColdownImage.fillAmount = 0;
        _abilityImage.sprite = _stats.AbilityIcon;
    }

    private IEnumerator Cooldown(float cooldown)
    {
        _isAbilityUsing = true;
        _abilityColdownImage.fillAmount = 1;

        while (_abilityColdownImage.fillAmount > 0)
        {
            _abilityColdownImage.fillAmount -= 1 / cooldown * Time.deltaTime;
            yield return null;
        }

        _abilityColdownImage.fillAmount = 0;
        _isAbilityUsing = false;
    }

    public virtual void Use()
    {
        if (_isAbilityUsing)
        {
            return;
        }
        StartCoroutine(UseAbilityAfterAnimation());
        StartCoroutine(Cooldown(_stats.Cooldown));
        SoundCaller.PlaySound(_stats.AbilitySound,true);
    }

    private IEnumerator UseAbilityAfterAnimation()
    {
        yield return StartCoroutine(this is UltimateAttack
            ? _playerAnimations.PlayerAbilityAnimation(true)
            : _playerAnimations.PlayerAbilityAnimation(false));

        InitAbility();
    }
}