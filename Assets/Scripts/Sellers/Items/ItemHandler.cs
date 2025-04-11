using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    [SerializeField] private Transform _itemsParent;
    [SerializeField] private Transform _buttonsParent;

    private void Start()
    {
        for (var i = 0; i < _itemsParent.childCount; i++)
        {
            var item = _itemsParent.GetChild(i).GetComponent<TradebleItem>();
            var button = _buttonsParent.GetChild(i).GetComponent<ShopBuyButton>();
            button.InitItemCost(item.GetItemCost());
        }
    }
}