using System.Collections;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _gatePosition;

    [SerializeField] private SpawnerData _spawnerData;
    public void StartWave()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        for (var i = 0; i < _spawnerData.Enemycount; i++)
        {
            yield return new WaitForSeconds(_spawnerData.SpawnRate);
            Vector3 _spawnOffset = new Vector2(Random.Range(_spawnerData.SpawnXmin, _spawnerData.SpawnXmax), Random.Range(-_spawnerData.SpawnY, _spawnerData.SpawnY));
            var newEnemy = Instantiate(_enemy, _gatePosition.position + _spawnOffset, _gatePosition.rotation);
            var enemy = newEnemy.GetComponent<Enemy>();
            enemy.Target = _gatePosition;
        }

    }
}
