using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private StartMoneyData _walletData;
    [SerializeField] private TMP_Text _moneytext; 
    private int _moneyCount;

    private void Start()
    {
        _moneyCount = _walletData.StartMoneyCount;
        UpdateDisplayMoney();
    }

    private void OnEnable()
    {
        ShopBuyButton.OnMoneyCheck += GetMoneyCount;
        ShopBuyButton.OnBuy += SpendMoney;
        Enemy.OnDropMoney += EarnMoney;
    }

    private void OnDisable()
    {
        ShopBuyButton.OnMoneyCheck -= GetMoneyCount;
        ShopBuyButton.OnBuy -= SpendMoney;
        Enemy.OnDropMoney -= EarnMoney;
    }

    private void EarnMoney(int money)
    {
        _moneyCount += money;
        UpdateDisplayMoney();
    }

    private int GetMoneyCount()
    {
        return _moneyCount;
    }

    private void SpendMoney(int money)
    {
        _moneyCount -= money;
        UpdateDisplayMoney();
    }

    private void UpdateDisplayMoney()
    {
        _moneytext.text = _moneyCount.ToString();
    }
}
