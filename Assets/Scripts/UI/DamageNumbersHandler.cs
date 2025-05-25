using UnityEngine;
using UnityEngine.Pool;

public class DamageNumbersHandler : MonoBehaviour
{
    [SerializeField] private GameObject _damageNumberPrefab;
    [SerializeField] private float _offset; 
    private readonly int _poolSize = 10;
    private readonly float _offsetZ = -0.1f;

    private ObjectPool<DamageNumber> _pool;

    private void Start()
    {
        _pool = new ObjectPool<DamageNumber>(
            CreateDamageNumber,
            OnTakeFromPool,
            OnReturnToPool,
            OnDestroyPoolObject,
            false, _poolSize, int.MaxValue
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

    private DamageNumber CreateDamageNumber()
    {
        var damageNumber = Instantiate(_damageNumberPrefab).GetComponent<DamageNumber>();
        return damageNumber;
    }

    private void OnTakeFromPool(DamageNumber damageNumber)
    {
        damageNumber.gameObject.SetActive(true);
    }

    private void OnReturnToPool(DamageNumber damageNumber)
    {
        damageNumber.gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(DamageNumber damageNumber)
    {
        Destroy(damageNumber.gameObject);
    }

    public void ReturnToPool(DamageNumber damageNumber)
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
