using AYellowpaper.SerializedCollections;
using UnityEngine;

public class ItemsDataHandler : MonoBehaviour
{
    [SerializedDictionary("ItemType", "Item")] [SerializeField]
    private SerializedDictionary<ItemTypes, Item> _items;

    private void OnEnable()
    {
        ShopBuyButton.OnTryBuyItem += GetItemCost;
    }

    private void OnDisable()
    {
        ShopBuyButton.OnTryBuyItem -= GetItemCost;
    }

    private int GetItemCost(ItemTypes itemType)
    {
        return _items[itemType].ItemsData.ItemCost;
    }
}