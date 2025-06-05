using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : Mob
{
    public static event Action OnPlayerDeath;

    [SerializeField] private PlayerBar _playerBars;
    [SerializeField] private Ability _firstAbility;
    [SerializeField] private Ability _secondAbility;
    [SerializeField] private Ability _thirdAbility;
    private PlayerModifiers playerModifiers;
    
    protected override bool PlayOneShot => true;
    protected override float ModifierSpeed => base.ModifierSpeed * playerModifiers.SpeedModifier;
    protected override float ModifierHealth => base.ModifierHealth * playerModifiers.HealthModifier;

    protected override void SetStats()
    {
        playerModifiers = GetComponent<PlayerModifiers>();
        base.SetStats();
        var playerStats = _damageableStats as PlayerStats;
        _playerBars.SetMaxHealth(playerStats.MaxHealth);
    }
    
    public void FirstAbility()
    {
        _firstAbility.Use();
    }
    
    public void SecondAbility()
    {
        _secondAbility.Use();
    }
    
    public void ThirdAbility()
    {
        _thirdAbility.Use();
    }

    protected override void Die()
    {
        OnPlayerDeath?.Invoke();
    }

    public override void TakeDamage(float recivedDamage)
    {
        base.TakeDamage(recivedDamage);
        _playerBars.ChangeValue(_currentHealth);
    }

    public void UpgradeMaxHealth(float upgradeHealth)
    {
        _currentHealth *= upgradeHealth;

        _playerBars.SetMaxHealth(ModifierHealth);
    }

    private void LevelUp()
    {
    }

    private void UpgradeAbility()
    {
    }

    private void UseWorkBench()
    {
    }

    private void EarnXp()
    {
    }

    private void OpenInventory()
    {
    }
}