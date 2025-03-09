using TMPro;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneytext;
    private int _moneyCount;
    public int MoneyCount
    {
        get => _moneyCount;
        set => _moneyCount = value;
    }

    public void SetStartMoney(int startMoney)
    {
        _moneyCount = startMoney;
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
    public void MoneyPickUp(int pickedMoney)
    {
        _moneyCount += pickedMoney;
    }
}
