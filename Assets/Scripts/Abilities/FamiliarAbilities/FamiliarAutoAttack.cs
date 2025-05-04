using System.Collections.Generic;
using UnityEngine;

public class FamiliarAutoAttack : MonoBehaviour, IFamiliarAbility
{
    [SerializeField] private float _damage;
    private readonly List<Enemy> _targetsInRange = new();
    
    public void Use()
    {
        _targetsInRange.RemoveAll(enemy => !enemy);

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
            if (!_targetsInRange.Contains(enemy))
            {
                _targetsInRange.Add(enemy);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                _targetsInRange.Remove(enemy);
            }
        }
    }
}
