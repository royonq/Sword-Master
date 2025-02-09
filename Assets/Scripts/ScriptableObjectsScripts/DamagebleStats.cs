using UnityEngine;
[CreateAssetMenu(fileName = "NewDamadeble", menuName = "Damageble")]
public class DamagebleStats : ScriptableObject
{
    [SerializeField] protected float _maxHealth;
    public float MaxHealth { get { return _maxHealth; } }
}
