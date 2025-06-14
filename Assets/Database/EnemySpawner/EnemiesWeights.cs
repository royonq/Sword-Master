using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyFactory", menuName = "Data/EnemiesWeights")]
public class EnemiesWeights : ScriptableObject
{
    [SerializeField] private EnemyWeight[] _enemyWeights;
    public EnemyWeight[] EnemyWeights => _enemyWeights;
}

[System.Serializable]
public struct EnemyWeight
{
    [SerializedDictionary("Enemy", "Weight")]
    [SerializeField] private SerializedDictionary<EnemyTypes, int> _enemies;
    public SerializedDictionary<EnemyTypes, int> Enemies => _enemies;
}
