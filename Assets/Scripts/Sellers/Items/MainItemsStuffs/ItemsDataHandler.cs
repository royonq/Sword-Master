using System;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class ItemsDataHandler : MonoBehaviour
{
    [SerializedDictionary("ItemType", "Item")] [SerializeField]
    private SerializedDictionary<ItemTypes, ItemsData> _items;

    private PlayerModifiers _playerModifiers;
    public static event Func<PlayerModifiers> OnModifier;


    private void OnEnable()
    {
        ShopBuyButton.OnTryBuyItem += GetItemCost;
        ShopBuyButton.OnBuyItem += GetItemModification;
    }

    private void OnDisable()
    {
        ShopBuyButton.OnTryBuyItem -= GetItemCost;
        ShopBuyButton.OnBuyItem -= GetItemModification;
    }

    private void Start()
    {
        _playerModifiers = OnModifier?.Invoke();
    }

    private int GetItemCost(ItemTypes itemType)
    {
        return _items[itemType].ItemCost;
    }

    private void GetItemModification(ItemTypes itemType)
    {
        _items[itemType].ApplyItem(_playerModifiers);
    }
}