using System;
using UnityEngine;

public class ShopBuyButton : MonoBehaviour
{
    public static event Action<int> OnBuy;
    public static Func<int> OnMoneyCheck;

    public void Buy()
    {
        if (OnMoneyCheck?.Invoke() < 5)//item cost
        {
            Debug.Log("No money");   
            return;
        }

        OnBuy?.Invoke(5);
    }
}