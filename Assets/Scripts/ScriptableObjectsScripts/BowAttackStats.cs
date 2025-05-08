using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Data/EnemyAbilities/BowAtack")]

public class BowAttackStats : ScriptableObject
{
    [SerializeField] private GameObject _bowArrow;
    public GameObject BowArrow => _bowArrow;

    [SerializeField] private float _attackCooldown;
    public float AttackCooldown => _attackCooldown;
    
    [SerializeField] private float _speed;
    public float Speed => _speed;
    [SerializeField] private float _timeToDestroy;
    public float TimeToDestroy => _timeToDestroy;
}
