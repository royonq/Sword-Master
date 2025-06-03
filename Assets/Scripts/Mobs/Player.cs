using System;
using UnityEngine;

public class Player : Mob
{
    public static event Action OnPlayerDeath;

    [SerializeField] private PlayerBar _playerBars;
    [SerializeField] private Ability _deafultAttack;
    [SerializeField] private Ability _ultimate;
    [SerializeField] private Ability _dash;
    private PlayerModifiers playerModifiers;

    private bool IsDashing => _dash.IsAbilityUsing;
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
    
    public override void Move(Vector2 direction)
    {
        if (IsDashing)
        {
            return;
        }
        base.Move(direction);
    }

    public void FirstAbility()
    {
        _deafultAttack.Use();
    }

    public void SecondAbility()
    {
        _ultimate.Use();
    }

    public void ThirdAbility()
    {
        _dash.Use();
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