using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Data/Abilities/ProjectileAfterHitStats")]
public class ProjectileAfterHitStats : ScriptableObject
{
    [SerializeField] private float _damage;
    private float Damage => _damage;
  
    [SerializeField] private float _speed;
    private float Speed => _speed;
  
    [SerializeField] private float _lifetime;
    private float Lifetime => _lifetime;
    
    public readonly struct SplitStats
    {
        private readonly ProjectileAfterHitStats _projectile;
        public float InitDamage => _projectile.Damage;
        public float InitSpeed => _projectile.Speed;
        public float InitLifetime => _projectile.Lifetime;
        public SplitStats(ProjectileAfterHitStats projectile)
        {
            _projectile = projectile;
        }
    }

}

