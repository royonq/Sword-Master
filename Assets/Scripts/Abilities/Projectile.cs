using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public static event Func<PlayerModifiers> OnModifier;
    
    protected float _speed;
    private float _deafultDamage;
    private float _lifeTime;
    
    private float ModifierDamage => (float)(_deafultDamage * OnModifier?.Invoke().DamageModifire);
    
    public virtual void Init(AbilityStats stats)
    {
        _deafultDamage = stats.Damage;
        _speed = stats.Speed;
        _lifeTime = stats.Lifetime;

        Destroy(gameObject, _lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collision.GetComponent<Mob>().TakeDamage(ModifierDamage);
           
            Destroy(gameObject);
        }
    }
}
