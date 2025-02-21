using System.Collections;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _gatePosition;

    [SerializeField] private SpawnerData _spawnerData;
    [SerializeField] private int _enemycount;

    public void StartWave()
    {
        StartCoroutine(SpawnEnemy());
    }

    public IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < _enemycount; i++)
        {
            yield return new WaitForSeconds(_spawnerData.SpawnRate);
            Vector3 _spawnOffset = new Vector2(Random.Range(_spawnerData.SpawnXmin, _spawnerData.SpawnXmax), Random.Range(-_spawnerData.SpawnY, _spawnerData.SpawnY));
            GameObject newEnemy = Instantiate(_enemy, _gatePosition.position + _spawnOffset, _gatePosition.rotation);
            Enemy enemy = newEnemy.GetComponent<Enemy>();
            enemy.Target = _gatePosition;
        }

    }
}
