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
    }
    
    
    protected override void InitAbility()
    {
        var instancedAbility = Instantiate(_ability, _spawnpoint.position, Quaternion.identity);
        InitProjectileAbility(instancedAbility, _projectileStats);
    }

    
    protected virtual void InitProjectileAbility(GameObject instancedAbility, ProjectileStats stats)
    {
        float finalDamage = stats.Damage + _damageModifier;
        float finalSpeed = stats.Speed + _speedModifier;
        float finalLifetime = stats.Lifetime;
        instancedAbility.GetComponent<Projectile>().Init(finalDamage, finalSpeed, finalLifetime, _playerModifiers);
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

        if (itemData is UpgradeSrowSwordAttack upgrade)
        {
            _damageModifier += upgrade.IncreaseDamage;
            _speedModifier += upgrade.IncreaseSpeed;
            _cooldownModifier += upgrade.IncreaseCooldown;
        }

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
        while (_isAbilityUpgraded && _canUseAbility)
        {
            base.Use();
            var cooldown = Mathf.Max(0.1f, _projectileStats.Cooldown - _cooldownModifier);
            yield return new WaitForSeconds(cooldown);
        }
    }
}