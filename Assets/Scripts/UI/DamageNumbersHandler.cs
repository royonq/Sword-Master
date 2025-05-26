using UnityEngine;
using UnityEngine.Pool;

public class DamageNumbersHandler : MonoBehaviour
{
    [SerializeField] private GameObject _damageNumberPrefab;
    [SerializeField] private float _offset;
    private readonly int _minPoolSize = 20;
    private readonly int _maxPoolSize = 70;
    private readonly float _offsetZ = -0.1f;

    private ObjectPool<DamageNumber> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<DamageNumber>(
            createFunc: () => Instantiate(_damageNumberPrefab).GetComponent<DamageNumber>(),
            actionOnGet: dn => dn.gameObject.SetActive(true),
            actionOnRelease: dn => dn.gameObject.SetActive(false),
            actionOnDestroy: dn => Destroy(dn.gameObject),
            collectionCheck: false,
            defaultCapacity: _minPoolSize,
            maxSize: _maxPoolSize
        );
    }
    
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
        _pool.Release(damageNumber);
    }

    private void ShowDamageNumber(float damage, Vector2 enemyPosition)
    {
        float offsetX = Random.Range(-_offset, _offset);
        Vector3 spawnPosition = new Vector3(enemyPosition.x + offsetX, enemyPosition.y, _offsetZ);

        var damageNumber = _pool.Get();
        damageNumber.transform.position = spawnPosition;
        damageNumber.Init(this);
        damageNumber.SetDamage(damage);
    }
}
