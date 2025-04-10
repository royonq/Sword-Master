using UnityEngine;

[CreateAssetMenu(fileName = "NewTradebleItem", menuName = "Data/SellersItems")]
public class ItemsData : ScriptableObject
{
    [SerializeField] private int _itemCost;
    public int ItemCost => _itemCost;
}
