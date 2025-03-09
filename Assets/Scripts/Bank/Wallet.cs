using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private WalletDatabase _walletData;
    [SerializeField] private TMP_Text _moneytext; 
    private int _moneyCount;

    private void Start()
    {
        _moneyCount = _walletData.MoneyCount;
        _moneytext.text = _moneyCount.ToString();
    }

    private void OnEnable()
    {
        Enemy.OnDropMoney += EarnMoney;
    }

    private void OnDisable()
    {
        Enemy.OnDropMoney -= EarnMoney;
    }

    private void EarnMoney(int money)
    {
        _moneyCount += money;
        _moneytext.text = _moneyCount.ToString();
    }
}
