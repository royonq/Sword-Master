using UnityEngine;

[CreateAssetMenu(fileName = "NewTradebleItem", menuName = "Data/SellersItems/Familiar")]
public class FamiliarData : ItemsData
{
    [SerializeField] private GameObject familiarPrefab;
    
    [SerializeField] private float _familiarSpeed;
    public float FamiliarSpeed => _familiarSpeed;

    public override void ApplyItem(PlayerModifiers playerModifiers)
    {
        playerModifiers.SpawnFamiliar(familiarPrefab);
    }
}