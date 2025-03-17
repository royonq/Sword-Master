using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] private GameObject _ability;
    [SerializeField] private Transform _spawnpoint;
    [SerializeField] private AbilityStats _stats;
    [SerializeField] private PlayerAnimations _playerAnimations;

    [SerializeField] private Image _abilityColdownImage;
    [SerializeField] private Image _abilityImage;
    private bool _isAbilityCooldown;

    protected virtual void InitAbility(GameObject instancedAbility, AbilityStats stats)
    {
        instancedAbility.GetComponent<Projectile>().Init(stats);
    }

    private void Start()
    {
        SetAbilityImage();
    }

    private void SetAbilityImage()
    {
        _abilityColdownImage.fillAmount = 0;
        _abilityImage.sprite = _stats.AbilityIcon;
    }
    
    
    
    private IEnumerator Cooldown(float cooldown)
    {
        _isAbilityCooldown = true;
        
        _abilityColdownImage.fillAmount = 1;

        while (_abilityColdownImage.fillAmount > 0)
        {
            _abilityColdownImage.fillAmount -= 1 / cooldown * Time.deltaTime;
            yield return null;
            
        }
        _abilityColdownImage.fillAmount = 0;
        _isAbilityCooldown = false;
    }

    public void Use()
    {
        if (_isAbilityCooldown)
        {
            return;
        }


        StartCoroutine(this is UltimateAttack
            ? _playerAnimations.PlayerAbilityAnimation(true)
            : _playerAnimations.PlayerAbilityAnimation(false));

        StartCoroutine(WaitForAnimationToEnd());
    }

    private IEnumerator WaitForAnimationToEnd()
    {
        while (_playerAnimations.IsAnimationPlay)
        {
            yield return null;
        }

        InitInstanceAbility();
    }

    private void InitInstanceAbility()
    {
        var instancedAbility = Instantiate(_ability, _spawnpoint.position, Quaternion.identity);
        InitAbility(instancedAbility, _stats); 
        StartCoroutine(Cooldown(_stats.Cooldown));
    }
}
