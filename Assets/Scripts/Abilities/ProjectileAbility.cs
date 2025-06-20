using System;
using UnityEngine;

public abstract class ProjectileAbility : Ability
{
    public static Action OnTryUseAutoAbility;
    [SerializeField] private Transform _spawnpoint;
    [SerializeField] private GameObject _ability;

    protected ProjectileStats _projectileStats;
    protected float _damageModifier;
    protected float _speedModifier;
    protected float _cooldownModifier;
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
        instancedAbility.GetComponent<Projectile>().Init(_damageModifier, _speedModifier, _lifeTime,_isAbilityUpgraded, _playerModifiers.DamageModifier,null );
    }

    
    protected virtual void EnableAbility()
    {
        _canUseAbility = true;
    }

    protected virtual void DisableAbility()
    {
        _canUseAbility = false;
    }
}