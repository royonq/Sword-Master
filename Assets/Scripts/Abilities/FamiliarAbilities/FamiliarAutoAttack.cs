using System.Collections.Generic;
using UnityEngine;

public class FamiliarAutoAttack : MonoBehaviour, IFamiliarAbility
{
    [SerializeField] private FamiliarAutoatackData _familiarAutoatackData;

    private readonly List<Enemy> _targetsInRange = new();
    private CircleCollider2D _boxCollider2D;

    private float _damage;
    private float _abilityRadius;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _damage = _familiarAutoatackData.Damage;
        _boxCollider2D = GetComponent<CircleCollider2D>();
        _boxCollider2D.radius = _familiarAutoatackData.AbilityRadius;
    }

    public void Use()
    {
        foreach (var enemy in _targetsInRange)
        {
            enemy.TakeDamage(_damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<Enemy>();
            _targetsInRange.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<Enemy>();
            _targetsInRange.Remove(enemy);
        }
    }
}