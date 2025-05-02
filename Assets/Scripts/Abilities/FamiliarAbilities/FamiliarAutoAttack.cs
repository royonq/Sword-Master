using System.Collections.Generic;
using UnityEngine;

public class FamiliarAutoAttack : MonoBehaviour, IFamiliarAbility
{
    [SerializeField] private float _damage;
    private readonly List<GameObject> _targetsInRange = new();

    public void Use()
    {
        _targetsInRange.RemoveAll(enemy => !enemy);

        foreach (var enemy in _targetsInRange)
        {
            enemy.GetComponent<Enemy>().TakeDamage(_damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !_targetsInRange.Contains(other.gameObject))
        {
            _targetsInRange.Add(other.gameObject);
        }
    }
}