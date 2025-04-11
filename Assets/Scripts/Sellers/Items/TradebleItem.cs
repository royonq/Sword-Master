using UnityEngine;

public class TradebleItem : MonoBehaviour
{
    [SerializeField] private ItemsData _itemsData;

    private int _cost;

    private void Awake()
    {
        SetItemStats();
    }

    private void SetItemStats()
    {
        _cost = _itemsData.ItemCost;
    }

    public int GetItemCost()
    {
        return _cost;
    }
}