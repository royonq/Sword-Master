using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] private GameObject _ability;
    [SerializeField] private Transform _spawnpoint;
    [SerializeField] private AbilityStats _stats;
    [SerializeField] private PlayerAnimations _playerAnimations;
    [SerializeField] private PlayerModifiers _playerModifiers;

    [SerializeField] private Image _abilityColdownImage;
    [SerializeField] private Image _abilityImage;
    private bool _isAbilityUsing;
    protected virtual void InitProjectileAbility(GameObject instancedAbility, AbilityStats stats)
    {
        var physicalStats = stats as PhysicalAbilityStats;
        instancedAbility.GetComponent<Projectile>().Init(physicalStats, _playerModifiers);
    }

    private void Start()
    {
        SetAbilityImage();
    }

    private void SetAbilityImage()
    {
        _abilityColdownImage.fillAmount = 0;
        _abilityImage.sprite = _stats.AbilityIcon; //todo походу нужно будет делать очередной базовый класс
    }

    protected IEnumerator Cooldown(float cooldown)
    {
        _abilityColdownImage.fillAmount = 1;

        while (_abilityColdownImage.fillAmount > 0)
        {
            _abilityColdownImage.fillAmount -= 1 / cooldown * Time.deltaTime;
            yield return null;
        }

        _abilityColdownImage.fillAmount = 0;
        _isAbilityUsing = false;
    }

    public void Use()
    {
        if (_isAbilityUsing)
        {
            return;
        }

        StartCoroutine(UseAbilityAfterAnimation());
        SoundCaller.PlaySound(_stats.AttackSound,true);
    }

    private IEnumerator UseAbilityAfterAnimation()
    {
        _isAbilityUsing = true;
        yield return StartCoroutine(this is UltimateAttack
            ? _playerAnimations.PlayerAbilityAnimation(true)
            : _playerAnimations.PlayerAbilityAnimation(false));

        InitInstanceAbility();
    }

    protected virtual void InitInstanceAbility()
    {
        var instancedAbility = Instantiate(_ability, _spawnpoint.position, Quaternion.identity);
        InitProjectileAbility(instancedAbility, _stats);
        StartCoroutine(Cooldown(_stats.Cooldown));
    }
}