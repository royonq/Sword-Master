using UnityEngine;

public class Player : Mob
{
    [SerializeField] private MobStats _mobStats;

    private float _moneyCount;

    private void Start()
    {
        SetStats(_mobStats);
    }

    protected override void SetStats(MobStats mobStats)
    {
        base.SetStats(mobStats);

        PlayerStats playerStats = mobStats as PlayerStats;

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
