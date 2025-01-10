public class Player : Mob
{
    private Ability _ability;
    private float _moneyCount;
    private void Start()
    {
       _ability = GetComponentInChildren<Ability>();
    }
    protected override void SetStats()
    {
        base.SetStats();

        PlayerStats playerStats = _mobStats as PlayerStats;

        _moneyCount = playerStats.MoneyCount;
    }

    public void Attack()
    {
        _ability.Use();
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
