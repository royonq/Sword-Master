using System;
using UnityEngine;

public class ShopBuyButton : MonoBehaviour
{
    public static event Action<int> OnBuy;
    public static Func<int> OnMoneyCheck;
    public static Func<ItemTypes, int> OnTryBuyItem;
    public static Action<ItemTypes> OnBuyItem;

    [SerializeField] private ItemTypes _itemType;

    public void Buy()
    {
        int itemCost = (int)OnTryBuyItem?.Invoke(_itemType);

        if (OnMoneyCheck?.Invoke() < itemCost)
        {
            Debug.Log("No money");
            return;
        }

        OnBuy?.Invoke(itemCost);
        OnBuyItem?.Invoke(_itemType);
    }
}