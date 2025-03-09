using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Data/Damageble/Enemy")]

public class EnemyStats : MobStats
{
    [SerializeField] private int _moneyToDrop;
    public int MoneyToDrop => _moneyToDrop;

    [SerializeField] private float _killExpirience;
    public float KillExpirience { get { return _killExpirience; } }
    
    
}
