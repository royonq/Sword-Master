using UnityEngine;

[CreateAssetMenu(fileName = "NewDamageArea", menuName = "Data/DamageArea")]
public class EnemyDamageAreaStats : ScriptableObject
{
    [SerializeField] private float _zoneArea;
    public float ZoneArea => _zoneArea;

    [SerializeField] private float _damage;
    public float Damage => _damage;
    
}
