using System;
using UnityEngine;
using System.Collections;

public abstract class ProjectileAbility : Ability
{
    public static Action OnTryUseAutoAbility;
    [SerializeField] private Transform _spawnpoint;
    [SerializeField] private GameObject _ability;

    private ProjectileStats _projectileStats;
    private float _damageModifier;
    private float _speedModifier;
    private float _cooldownModifier;
    private float _lifeTime;
    public bool _canUseAbility;

    private void OnEnable()
    {
        SpawnEnemies.OnStartWave += EnableAbility;
        SpawnEnemies.OnGameWin += DisableAbility;
    }

    private void OnDisable()
    {
        SpawnEnemies.OnStartWave -= EnableAbility;
        SpawnEnemies.OnGameWin -= DisableAbility;
    }
    
    
    private void Awake()
    {
        _projectileStats = _stats as ProjectileStats;
        _damageModifier = _projectileStats.Damage;
        _speedModifier = _projectileStats.Speed;
        _lifeTime = _projectileStats.Lifetime;
    }
    
    
    protected override void InitAbility()
    {
        var instancedAbility = Instantiate(_ability, _spawnpoint.position, Quaternion.identity);
        InitProjectileAbility(instancedAbility);
    }

    
    protected virtual void InitProjectileAbility(GameObject instancedAbility)
    {
        instancedAbility.GetComponent<Projectile>().Init(_damageModifier, _speedModifier, _lifeTime, _playerModifiers);
    }

    
    private void EnableAbility()
    {
        _canUseAbility = true;
        if (_isAbilityUpgraded)
        {
            StartCoroutine(AutoUse());
        }
    }

    private void DisableAbility()
    {
        _canUseAbility = false;
        StopCoroutine(AutoUse());
    }
    
    
    public override void UpgradeAbility(ItemsData itemData)
    {
        base.UpgradeAbility(itemData);
        var data = itemData as UpgradeSrowSwordAttack;

        _damageModifier += data.IncreaseDamage;
        _speedModifier += data.IncreaseSpeed;
        _cooldownModifier += data.IncreaseCooldown;


        _abilityImage.color = Color.gray;
    }

    
    public override void Use()
    {
        if (!_canUseAbility)
        {
            return;
        }

        if (_isAbilityUpgraded)
        {
            OnTryUseAutoAbility?.Invoke();
            return;
        }
     
        base.Use();
    }

    
    private IEnumerator AutoUse()
    {
        while (_canUseAbility)
        {
            base.Use();
            var cooldown = _projectileStats.Cooldown - _cooldownModifier;
            yield return new WaitForSeconds(cooldown);
        }
    }
}