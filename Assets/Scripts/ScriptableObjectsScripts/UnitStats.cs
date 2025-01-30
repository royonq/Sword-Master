using UnityEngine;
[CreateAssetMenu(fileName = "NewUnit", menuName = "Unit")]
public class UnitStats : ScriptableObject
{
    [SerializeField] protected float _health;
    public float Health { get { return _health; } }
}
