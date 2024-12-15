using UnityEngine;

public class Player : Mob
{
    [SerializeField] PlayerStats _playerStats;

    private float _moneyCount;

    private void Start()
    {
        SetStats(_playerStats);
    }

    protected override void SetStats(MobStats mobStats)
    {
        base.SetStats(mobStats);

        _moneyCount = _playerStats.MoneyCount;
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
