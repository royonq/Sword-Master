using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _playerPosition;
    [SerializeField] float _spawnRadius;
    [SerializeField] private float _spawnRate;
    [SerializeField] private FollowTarget _followTarget;

    private void Start()
    {
        _followTarget.Target = _playerPosition;
        StartCoroutine(SpawnRate());
    }
    private IEnumerator SpawnRate()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnRate);
            Vector3 _spawnOffset = new Vector2(Random.Range(-_spawnRadius, _spawnRadius), Random.Range(-_spawnRadius, _spawnRadius));
            Instantiate(_enemy, _playerPosition.position + _spawnOffset, _playerPosition.rotation);
        }
    }
}
