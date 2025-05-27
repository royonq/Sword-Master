using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;

public class DamageNumbersHandler : MonoBehaviour
{
    [SerializeField] private GameObject _damageNumberPrefab;
    [SerializeField] private DamageNumberStats _damageNumberStats;
    [SerializeField] private float _offset;
    private readonly int _minPoolSize = 20;
    private readonly int _maxPoolSize = 70;
    private readonly float _offsetZ = -0.1f;

    private ObjectPool<GameObject> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(_damageNumberPrefab),
            actionOnGet: damageNumber => damageNumber.SetActive(true),
            actionOnRelease: damageNumber => damageNumber.SetActive(false),
            actionOnDestroy: Destroy,
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
    
    private void ShowDamageNumber(float damage, Vector2 enemyPosition)
    {
        var offsetX = Random.Range(-_offset, _offset);
        var spawnPosition = new Vector3(enemyPosition.x + offsetX, enemyPosition.y, _offsetZ);

        var damageNumber = _pool.Get();
        var _text = damageNumber.GetComponent<TextMeshPro>();
        _text.text = damage.ToString("0");
        damageNumber.transform.position = spawnPosition;
        StartCoroutine(MoveAndReturn(damageNumber));
    }
    
    private IEnumerator MoveAndReturn(GameObject damageNumber)
    {
        var lifetime = _damageNumberStats.LifeTime;
        while (lifetime > 0)
        {
            damageNumber.transform.position += Vector3.up * (_damageNumberStats.MoveUpSpeed * Time.fixedDeltaTime);
            lifetime -= Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        _pool.Release(damageNumber);
    }
}
