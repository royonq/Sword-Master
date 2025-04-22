using System;
using UnityEngine;

public class Player : Mob
{
    public static event Action OnPlayerDeath;

    [SerializeField] private PlayerBar _playerBars;
    [SerializeField] private Ability _deafultAttack;
    [SerializeField] private Ability _ultimate;

    private PlayerModifiers playerModifiers;
    protected override float ModifierSpeed => base.ModifierSpeed * playerModifiers.SpeedModifier;
    protected override float ModifierHealth => base.ModifierHealth * playerModifiers.HealthModifier;

    protected override void SetStats()
    {
        playerModifiers = GetComponent<PlayerModifiers>();
        base.SetStats();
        var playerStats = _damagableStats as PlayerStats;
        _playerBars.SetMaxHealth(playerStats.MaxHealth);
    }

    public void Attack()
    {
        _deafultAttack.Use();
    }

    public void UseUltimate()
    {
        _ultimate.Use();
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