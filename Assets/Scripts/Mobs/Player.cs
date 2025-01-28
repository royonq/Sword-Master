using UnityEngine;

public class Player : Mob
{
    [SerializeField] private Ability _deafultAttack;
    [SerializeField] private Ability _ultimate;
    private float _moneyCount;
    protected override void SetStats()
    {
        base.SetStats();

        PlayerStats playerStats = _mobStats as PlayerStats;

        _moneyCount = playerStats.MoneyCount;
    }

    public void Attack()
    {
        _deafultAttack.Use();
    }

    public void UseUltimate()
    {
        _ultimate.Use();
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
