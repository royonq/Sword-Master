using UnityEngine;

public class DamageNumbersHandler: MonoBehaviour
{
    [SerializeField] private GameObject _damageNumberPrefab;
    
    [SerializeField] private float _offset;
    private readonly float _offsetZ = -0.1f;

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
        float offsetX = Random.Range(-_offset, _offset);
        var spawnPosition = new Vector3(enemyPosition.x + offsetX, enemyPosition.y, _offsetZ);
        var damageNumber = Instantiate(_damageNumberPrefab, spawnPosition, Quaternion.identity);
        damageNumber.GetComponent<DamageNumber>().SetDamage(damage);
    }
}
