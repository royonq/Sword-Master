using UnityEngine;

public class Player : Mob
{
    [SerializeField] private PlayerBar _playerBars;
    [SerializeField] private Ability _deafultAttack;
    [SerializeField] private Ability _ultimate;
    [SerializeField] private Defeat _defeat;
    private float _moneyCount;
    protected override void SetStats()
    {
        base.SetStats();

        PlayerStats playerStats = _damagableStats as PlayerStats;

        _moneyCount = playerStats.MoneyCount;

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
        _defeat.GameOver();
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

    private void EarnXP()
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
