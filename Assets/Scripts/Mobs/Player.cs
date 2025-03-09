using System;
using UnityEngine;

public class Player : Mob
{
    public static event Action OnPlayerDeath;

    [SerializeField] private PlayerBar _playerBars;
    [SerializeField] private Ability _deafultAttack;
    [SerializeField] private Ability _ultimate;
    [SerializeField] private PlayerWallet _playerWallet;


    protected override void SetStats()
    {
        base.SetStats();

        var playerStats = _damagableStats as PlayerStats;

        _playerWallet.SetStartMoney(playerStats.StartMoney);
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

    public void MoneyPickUp(int pickedMoney)
    {
        _playerWallet.MoneyCount += pickedMoney;
    }
}