using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemies : MonoBehaviour
{
    public static event Action OnGameWin;
    public static event Action OnStartWave;
    
    public static event Action<int, Vector3> OnSpawnEnemy;

    [SerializeField] private GameObject _waveHandler;
    [SerializeField] private GameObject _gate;

    [SerializeField] private SpawnerData _spawnerData;
    [SerializeField] private EnemyFactory _enemyFactory;

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
            OnSpawnEnemy?.Invoke(_waveCounter, _spawnOffset);
        }
        _waveCounter++;
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
