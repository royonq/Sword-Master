using UnityEngine;
[CreateAssetMenu(fileName = "NewDamadeble", menuName = "Data/Damageble/Damageble")]
public class DamagebleStats : ScriptableObject
{
    [SerializeField] protected float _maxHealth;
    public float MaxHealth => _maxHealth;
}
