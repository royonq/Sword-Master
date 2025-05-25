using System.Collections.Generic;
using UnityEngine;

public class DamageNumbersHandler : MonoBehaviour
{
    [SerializeField] private GameObject _damageNumberPrefab;
    [SerializeField] private float _offset;
    private readonly float _offsetZ = -0.1f;

    private readonly Queue<DamageNumber> _pool = new();
    private Vector3 _spawnPosition;

    private void OnEnable()
    {
        Enemy.OnTakeDamage += ShowDamageNumber;
    }
    private void OnDisable()
    {
        Enemy.OnTakeDamage -= ShowDamageNumber;
    }

    public void AddToPool(DamageNumber damageNumber)
    {
        damageNumber.gameObject.SetActive(false);
        _pool.Enqueue(damageNumber);
    }

    private DamageNumber GetFromPool()
    {
        if (_pool.Count == 0)
        {
            return SpawnDamageNumber();
        }

        var damageNumber = _pool.Dequeue();
        damageNumber.gameObject.SetActive(true);
        damageNumber.transform.position = _spawnPosition;
        return damageNumber;
    }

    private DamageNumber SpawnDamageNumber()
    {
        var damageNumber = Instantiate(_damageNumberPrefab, _spawnPosition, Quaternion.identity);
        return damageNumber.GetComponent<DamageNumber>();
    }

    private void ShowDamageNumber(float damage, Vector2 enemyPosition)
    {
        var offsetX = Random.Range(-_offset, _offset);
        _spawnPosition = new Vector3(enemyPosition.x + offsetX, enemyPosition.y, _offsetZ);
        var damageNumber = GetFromPool();
        damageNumber.transform.position = _spawnPosition;
        damageNumber.Init(this);
        damageNumber.SetDamage(damage);
    }
}
