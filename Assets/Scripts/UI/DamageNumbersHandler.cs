using UnityEngine;
using UnityEngine.Pool;

public class DamageNumbersHandler : MonoBehaviour
{
    [SerializeField] private DamageNumber _damageNumberPrefab;
    [SerializeField] private float _offset;
    private readonly int _minPoolSize = 20;
    private readonly int _maxPoolSize = 70;
    private readonly float _offsetZ = -0.1f;

    private ObjectPool<DamageNumber> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<DamageNumber>(
            createFunc: () => Instantiate(_damageNumberPrefab),
            actionOnGet: damageNumber => damageNumber.gameObject.SetActive(true),
            actionOnRelease: damageNumber => damageNumber.gameObject.SetActive(false),
            actionOnDestroy: damageNumber => Destroy(damageNumber.gameObject),
            collectionCheck: false,
            defaultCapacity: _minPoolSize,
            maxSize: _maxPoolSize
        );
    }

    private void OnEnable()
    {
        Enemy.OnTakeDamage += ShowDamageNumber;
        DamageNumber.OnShowDamage += AddToPool;
    }

    private void OnDisable()
    {
        Enemy.OnTakeDamage -= ShowDamageNumber;
        DamageNumber.OnShowDamage -= AddToPool;
    }

    private void AddToPool(DamageNumber damageNumber)
    {
        _pool.Release(damageNumber);
    }

    private void ShowDamageNumber(float damage, Vector2 enemyPosition)
    {
        var offsetX = Random.Range(-_offset, _offset);
        var spawnPosition = new Vector3(enemyPosition.x + offsetX, enemyPosition.y, _offsetZ);

        var damageNumber = _pool.Get();
        damageNumber.Init(damage, spawnPosition);
    }
}
