using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
public abstract class Ability : MonoBehaviour
{
    [SerializeField] private GameObject _ability;
    [SerializeField] private Transform _spawnpoint;
    [SerializeField] private AbilityStats _stats;

    [SerializeField] private Image _abilityColdownImage;
    [SerializeField] private Image _abilityImage;
    private bool _isAbilityCooldown;
    private Animator _animator;
    private string _animationName;

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

    public void SetAnimation(Animator animator,string animationName)
    {
        _animator = animator;
        _animationName = animationName;
    }

    private IEnumerator Cooldown(float cooldown)
    {
        _isAbilityCooldown = true;
        
        _abilityColdownImage.fillAmount = 1;

        while (_abilityColdownImage.fillAmount > 0)
        {
            _abilityColdownImage.fillAmount -= 1 / cooldown * Time.deltaTime;
            yield return null;
            _animator?.SetBool(_animationName, false);
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
        _animator?.SetBool(_animationName, true);
        StartCoroutine(Cooldown(_stats.Cooldown));
        var instancedAbility = Instantiate(_ability, _spawnpoint.position, Quaternion.identity);
        InitAbility(instancedAbility, _stats);
    }
}
