public class Player : Mob
{
    private ThrowSwordAttack _throwSwordAttack;
    private float _moneyCount;
    private void Start()
    {
       _throwSwordAttack = GetComponentInChildren<ThrowSwordAttack>();
    }
    protected override void SetStats()
    {
        base.SetStats();

        PlayerStats playerStats = _mobStats as PlayerStats;

        _moneyCount = playerStats.MoneyCount;
    }

    public void Attack()
    {
        _throwSwordAttack.Throw();
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
