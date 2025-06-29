using System;
using UnityEngine;

public abstract class ProjectileAbility : Ability
{
    public static Action OnTryUseAutoAbility;
    [SerializeField] private Transform _spawnpoint;
    [SerializeField] private GameObject _ability;

    private ProjectileStates _states;
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
        _cooldownModifier = _projectileStats.Cooldown;
        _lifeTime = _projectileStats.Lifetime;

        _states = new ProjectileStates(this);
    }
    
    
    
    protected override void InitAbility()
    {
        var instancedAbility = Instantiate(_ability, _spawnpoint.position, Quaternion.identity);
        InitProjectileAbility(instancedAbility);
    }

    
    protected virtual void InitProjectileAbility(GameObject instancedAbility)
    {
        instancedAbility.GetComponent<Projectile>().Init(_states, _playerModifiers.DamageModifier);
    }

    
    protected virtual void EnableAbility()
    {
        _canUseAbility = true;
    }

    protected virtual void DisableAbility()
    {
        _canUseAbility = false;
    }

    public readonly struct ProjectileStates
    {
        private readonly ProjectileAbility _ability;
        public float Damage => _ability._damageModifier;
        public float Speed => _ability._speedModifier;
        public float LifeTime => _ability._lifeTime;
        public bool IsUpgraded => _ability._isAbilityUpgraded;

        public ProjectileStates(ProjectileAbility ability)
        {
            _ability = ability;
        }
    }
}