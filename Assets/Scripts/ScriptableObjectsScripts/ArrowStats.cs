using UnityEngine;

[CreateAssetMenu(fileName = "NewArrow", menuName = "Data/EnemyAbilities/Arrow")]
public class ArrowStats : ScriptableObject
{
    [SerializeField] private float _speed;
    public float Speed => _speed;
    [SerializeField] private float _damage;
    public float Damage => _damage;
}