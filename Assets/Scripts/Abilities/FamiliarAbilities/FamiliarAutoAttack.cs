using System.Collections.Generic;
using UnityEngine;

public class FamiliarAutoAttack : MonoBehaviour, IFamiliarAbility
{
    [SerializeField] private float _damage;
    private readonly List<Enemy> _targetsInRange = new();
    
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