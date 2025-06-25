using System;
using UnityEngine;

public abstract class ProjectileAbility : Ability
{
    public static Action OnTryUseAutoAbility;
    [SerializeField] private Transform _spawnpoint;
    [SerializeField] private GameObject _ability;

    private ProjectileState _state;
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

        _state = new ProjectileState
        {
            Damage = _projectileStats.Damage,
            Speed = _projectileStats.Speed,
            LifeTime = _projectileStats.Lifetime,
            IsUpgraded = _isAbilityUpgraded
        };
    }
    
    
    protected override void InitAbility()
    {
        var instancedAbility = Instantiate(_ability, _spawnpoint.position, Quaternion.identity);
        InitProjectileAbility(instancedAbility);
    }

    
    protected virtual void InitProjectileAbility(GameObject instancedAbility)
    {
        instancedAbility.GetComponent<Projectile>().Init(_state, _playerModifiers.DamageModifier);
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