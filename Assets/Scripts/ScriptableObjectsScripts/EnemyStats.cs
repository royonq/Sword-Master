using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Data/Damageble/Enemy")]

public class EnemyStats : MobStats
{
    [SerializeField] private int _moneyToDrop;
    public int MoneyToDrop => _moneyToDrop;

    [SerializeField] private float _killExpirience;

    public float KillExpirience => _killExpirience;

    [SerializeField] private float _attackDistance;
    public float AttackDistance => _attackDistance;
}
