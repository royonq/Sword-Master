using UnityEngine;

[CreateAssetMenu(fileName = "NewDamageArea", menuName = "Data/DamageArea")]
public class EnemyDamageAreaStats : EnemyAttackStats
{
    [SerializeField] private float _zoneArea;
    public float ZoneArea => _zoneArea;
}
