using System;
using UnityEngine;
using UnityEngine.Serialization;

public class WaveStartStop : MonoBehaviour
{
    public static event Action OnGameWin; 
    [SerializeField] private SpawnEnemies _spawnEnemies;
    [SerializeField] private GameObject _gate;
    [SerializeField] private SpawnerData _spawnerData;
    private int _enemyPerWaveCount;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        _enemyPerWaveCount = _spawnerData.Enemycount;
        _spawnEnemies.StartWave();
        Enemy.OnCountChange += UpdateEnemyCount;
        _gate.SetActive(true); //change to animation
        gameObject.SetActive(false);
    }


    private void UpdateEnemyCount()
    {
        _enemyPerWaveCount--;
        
        if (_enemyPerWaveCount == 0)
        {
            OnGameWin?.Invoke();
            Enemy.OnCountChange -= UpdateEnemyCount;
            _gate.SetActive(false);
        }
    }
}
