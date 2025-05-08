using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewDamageArea", menuName = "Data/DamageArea")]
public class EnemyDamageAreaStats : ScriptableObject
{ [SerializeField] private float _zoneArea;
    public float ZoneArea => _zoneArea;
}
