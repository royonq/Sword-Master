using System;
using UnityEngine;

public class ShopBuyButton : MonoBehaviour
{
    public static event Action<int> OnBuy;
    public static Func<int> OnMoneyCheck;

    private int _buyItemCost;

    public void InitItemCost(int itemCost)
    {
        _buyItemCost = itemCost;
    }

    public void Buy()
    {
        if (OnMoneyCheck?.Invoke() < _buyItemCost)
        {
            Debug.Log("No money");
            return;
        }

        OnBuy?.Invoke(_buyItemCost);
    }
}