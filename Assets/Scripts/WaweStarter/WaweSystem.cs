using System;
using UnityEngine;

public class WaweSystem : MonoBehaviour
{
    public static event Action OnGameWinn;
    [SerializeField] private SpawnEnemies _enemySpawner;
    [SerializeField] private GameObject _gate;
    [SerializeField] private SpawnerData _spawnerData;
    private int _enemyCount;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        _enemyCount = _spawnerData.Enemycount;
        _enemySpawner.StartWave();
        Enemy.OnCountChange += CheckEnemyCount;
        _gate.SetActive(true); //change to animation
        gameObject.SetActive(false);
    }


    private void CheckEnemyCount()
    {
        _enemyCount--;
        
        if (_enemyCount == 0)
        {
            OnGameWinn?.Invoke();
            Enemy.OnCountChange -= CheckEnemyCount;
            _gate.SetActive(false);
        }

        Debug.Log(_enemyCount);
    }
}
