using UnityEngine;
[CreateAssetMenu(fileName = "NewDamadeble", menuName = "Damageble")]
public class DamagebleStats : ScriptableObject
{
    [SerializeField] protected float _health;
    public float Health { get { return _health; } }
}
