using System;
using TMPro;
using UnityEngine;

public class Player : Mob
{
    public static event Action OnPlayerDeath;
    
    [SerializeField] private PlayerBar _playerBars;
    [SerializeField] private Ability _deafultAttack;
    [SerializeField] private Ability _ultimate;
    [SerializeField] private TextMeshProUGUI _Moneytext;
    private float _moneyCount;

    private void OnEnable()
    {
        Enemy.OnDropMoney += EarnMoney;
    }

    protected override void SetStats()
    {
        base.SetStats();

        var playerStats = _damagableStats as PlayerStats;


        _moneyCount = playerStats.MoneyCount;
        _Moneytext.text = _moneyCount.ToString();

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
        Enemy.OnDropMoney -= EarnMoney;
        OnPlayerDeath?.Invoke();
    }

    public override void TakeDamage(float recivedDamage)
    {
        base.TakeDamage(recivedDamage);

        _playerBars.ChangeValue(_currentHealth);
    }

    private void EarnMoney(int money)
    {
        _moneyCount += money;
        _Moneytext.text = _moneyCount.ToString();
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
        _moneyCount += pickedMoney;
    }
}