using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemies : MonoBehaviour
{
    public static event Action OnGameWin;
    public static event Action OnStartWave;

    [SerializeField] private GameObject _waveHandler;
    [SerializeField] private GameObject _gate;
    [SerializeField] private Transform _target;

    [SerializeField] private SpawnerData _spawnerData;
    
    private int _waveCounter;
    private int _enemyTotal;

    private void OnEnable()
    {
        Enemy.OnDeath += UpdateEnemyCount;
    }

    private void OnDisable()
    {
        Enemy.OnDeath -= UpdateEnemyCount;
    }

    public void StartWave()
    {
        _enemyTotal = _spawnerData.EnemyWave[_waveCounter];
        StartCoroutine(SpawnEnemy());
        _gate.SetActive(true);
        OnStartWave?.Invoke();
    }

    private IEnumerator SpawnEnemy()
    {
        for (var i = 0; i < _spawnerData.EnemyWave[_waveCounter]; i++)
        {
            
            yield return new WaitForSeconds(_spawnerData.SpawnRate);
            Vector3 _spawnOffset = new Vector2(Random.Range(_spawnerData.SpawnXmin, _spawnerData.SpawnXmax),
                Random.Range(-_spawnerData.SpawnY, _spawnerData.SpawnY));
            var newEnemy = Instantiate(GetRandomEnemy(_waveCounter), _target.position + _spawnOffset, transform.rotation);
            var enemy = newEnemy.GetComponent<Enemy>();
           
            enemy.SetTarget(_target);
        }

        _waveCounter++;
    }
    
    private GameObject GetRandomEnemy(int waveIndex)
    {
        var weights = _spawnerData.EnemyWeights[waveIndex].Enemies;
        int totalWeight = weights.Sum(pair => pair.Value);
        var random = Random.Range(0, totalWeight);
        var current = 0;
        
        foreach (var pair in weights)
        {
            current += pair.Value;
            if (random < current)
                return pair.Key;
        }
        throw new InvalidOperationException("Failed to select a random enemy. Check weights configuration."); 
    }
    
    private void UpdateEnemyCount()
    {
        _enemyTotal--;
        
        if (_enemyTotal <= 0)
        {
            OnGameWin?.Invoke();
            _waveHandler.SetActive(true);
            _gate.SetActive(false);
        }
    }
}