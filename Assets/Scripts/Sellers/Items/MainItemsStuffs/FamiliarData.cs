using UnityEngine;

[CreateAssetMenu(fileName = "NewTradebleItem", menuName = "Data/SellersItems/Familiar")]
public class FamiliarData : ItemsData
{ 
    [SerializeField] private GameObject _familiarPrefab;

    public override void ApplyItem(PlayerModifiers playerModifiers)
    {
        playerModifiers.SpawnFamiliar(_familiarPrefab);
    }
}