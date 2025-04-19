using System;
using UnityEngine;

public class Player : Mob
{
    public static event Action OnPlayerDeath;

    [SerializeField] private PlayerBar _playerBars;
    [SerializeField] private Ability _deafultAttack;
    [SerializeField] private Ability _ultimate;
    
    private PlayerModifires _playerModifires;
    protected override float ModifireSpeed => base.ModifireSpeed * _playerModifires.SpeedModifire;


    private void OnEnable()
    {
        Item.OnModifier += GetPlayerModifiers;
    }

    private void OnDisable()
    {
        Item.OnModifier -= GetPlayerModifiers;
    }

    protected override void SetStats()
    {
        base.SetStats();

        var playerStats = _damagableStats as PlayerStats;

        _playerBars.SetMaxHealth(playerStats.MaxHealth);

        _playerModifires = GetComponent<PlayerModifires>();
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

    private void LevelUp()
    {
    }

    private void Interact()
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

    private void BuyItem()
    {
    }

    private void OpenInventory()
    {
    }
    
}