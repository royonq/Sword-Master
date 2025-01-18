using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected float _damage;
    protected float _speed;
    protected float _lifeTime;

    public virtual void Init(AbilityStats stats)
    {
        _damage = stats.Damage;
        _speed = stats.Speed;
        _lifeTime = stats.Lifetime;
    }
}
