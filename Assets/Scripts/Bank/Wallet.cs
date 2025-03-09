using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneytext;
    [SerializeField] private int _moneyCount;

    private void Start()
    {
        _moneytext.text = _moneyCount.ToString();
    }

    private void OnEnable()
    {
        PickUpItems.OnPickUp += EarnMoney;
        Enemy.OnDropMoney += EarnMoney;
    }

    private void OnDisable()
    {
        PickUpItems.OnPickUp -= EarnMoney;
        Enemy.OnDropMoney -= EarnMoney;
    }

    private void EarnMoney(int money)
    {
        _moneyCount += money;
        _moneytext.text = _moneyCount.ToString();
    }
}
