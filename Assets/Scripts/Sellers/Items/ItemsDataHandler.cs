using UnityEngine;

public class ItemsDataHandler : MonoBehaviour
{
   [SerializeField] private ItemsData[] _items;

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
      return 10;
      //return _items[itemType].GetItemCost();
   }
    
}