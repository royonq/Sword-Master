using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Data/Damageble/Enemy")]

public class EnemyStats : MobStats
{
    [SerializeField] private int _moneyToDrop;
    public int MoneyToDrop => _moneyToDrop;

    [SerializeField] private float _killExpirience;

    public float KillExpirience => _killExpirience;

    [SerializeField] private float _attackDistance;
    public float AttackDistance => _attackDistance;
    
   [SerializeField] private float _attackDamage;
    public float AttackDamage => _attackDamage;
}
