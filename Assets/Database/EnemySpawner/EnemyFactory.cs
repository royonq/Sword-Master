using System;
using System.Linq;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyFactory : MonoBehaviour
{
    [SerializedDictionary("Enemy", "Prefab")] [SerializeField]
    private SerializedDictionary<EnemyTypes, GameObject> _enemies;

    [SerializeField] private EnemiesWeights _enemiesWeights;
    [SerializeField] private Transform _target;

    
    private void OnEnable()
    {
        SpawnEnemies.OnSpawnEnemy += SpawnEnemy;
    }

    private void OnDisable()
    {
        SpawnEnemies.OnSpawnEnemy -= SpawnEnemy;
    }

    public void SpawnEnemy(int waveCounter, Vector3 spawnOffset)
    {
        var weights = _enemiesWeights.EnemyWeights[waveCounter].Enemies;
        int totalWeight = weights.Values.Sum();

        var enemyType = GetRandomEnemyType(weights, totalWeight);

        var newEnemy = Instantiate(_enemies[enemyType], _target.position + spawnOffset, transform.rotation);
        var enemy = newEnemy.GetComponent<Enemy>();
        enemy.SetTarget(_target);
    }

    private EnemyTypes GetRandomEnemyType(SerializedDictionary<EnemyTypes, int> weights, int totalWeight)
    {
        int random = Random.Range(0, totalWeight);
        int current = 0;

        foreach (var pair in weights)
        {
            current += pair.Value;
            if (random < current)
                return pair.Key;
        }

        throw new Exception("Failed to select a random enemy. Check weights configuration.");
    }
}
