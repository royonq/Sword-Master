using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Data/Abilities/ProjectileAfterHitStats")]
public class ProjectileAfterHitStats : ScriptableObject
{
    [SerializeField] private float _damage;
    public float Damage => _damage;
  
    [SerializeField] private float _speed;
    public float Speed => _speed;
  
    [SerializeField] private float _lifetime;
    public float Lifetime => _lifetime;
}
