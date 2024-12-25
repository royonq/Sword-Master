using UnityEngine;
[CreateAssetMenu(fileName = "NewEnemy", menuName = "Enemy")]

public class EnemyStats : MobStats
{
    [SerializeField] private float _killExpirience;
    public float KillExpirience { get { return _killExpirience; } }
}
