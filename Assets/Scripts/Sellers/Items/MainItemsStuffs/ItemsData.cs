using UnityEngine;

[CreateAssetMenu(fileName = "NewTradebleItem", menuName = "Data/SellersItems")]
public abstract class ItemsData : ScriptableObject
{
    [SerializeField] protected int _itemCost;
    public int ItemCost => _itemCost;

    public abstract void ApplyItem(PlayerModifiers playerModifiers);
}