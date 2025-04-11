using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    [SerializeField] private List<TradebleItem> _items = new();

    [SerializeField] private List<ShopBuyButton> _buyButtons = new List<ShopBuyButton>();

    private void Start()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            _buyButtons[i].InitItemCost(_items[i].GetItemCost());
        }
    }
}