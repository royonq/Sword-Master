using System.Collections;
using UnityEngine;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    [SerializeField] private DamageNumberStats _damageNumberStats;

    private float _moveUpSpeed;
    private float _lifeTime;
    private TextMeshPro _text;

    public void Init(DamageNumbersHandler handler)
    {
        _lifeTime = _damageNumberStats.LifeTime;
        _moveUpSpeed = _damageNumberStats.MoveUpSpeed;
        _text = GetComponent<TextMeshPro>();
        StartCoroutine(MoveAndReturn(handler));
    }

    public void SetDamage(float damage)
    {
        _text.text = damage.ToString("0");
    }

    private IEnumerator MoveAndReturn(DamageNumbersHandler pool)
    {
        while (_lifeTime > 0)
        {
            transform.position += Vector3.up * (_moveUpSpeed * Time.fixedDeltaTime);
            _lifeTime -= Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        pool.AddToPool(this);
    }
}
