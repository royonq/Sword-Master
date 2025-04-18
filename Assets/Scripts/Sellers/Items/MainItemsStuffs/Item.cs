using System;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public static event Func<PlayerModifires> OnModifier;
    
    [SerializeField] protected ItemsData _itemsData;
    public ItemsData ItemsData => _itemsData;

    private void OnEnable()
    {
        ShopBuyButton.OnApplyItem += ApplyItem;
    }

    private void OnDisable()
    {
        ShopBuyButton.OnApplyItem -= ApplyItem;
    }

    protected PlayerModifires  GetModifier()
    {
       return OnModifier?.Invoke();
    }

    protected abstract void ApplyItem();
}
