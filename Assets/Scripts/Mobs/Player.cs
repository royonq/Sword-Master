using UnityEngine;

public class Player : Mob
{

    private float _moneyCount;

    protected override void SetStats()
    {

        base.SetStats();

        PlayerStats playerStats = _mobStats as PlayerStats;

        _moneyCount = playerStats.MoneyCount;
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
