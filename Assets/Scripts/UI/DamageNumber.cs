using System.Collections;
using UnityEngine;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    [SerializeField] private DamageNumberStats _damageNumberStats;

    private float _moveUpSpeed;
    private float _lifeTime;
    private TextMeshPro _text;

    public void Init(DamageNumbersHandler pool)
    {
        _lifeTime = _damageNumberStats.LifeTime;
        _moveUpSpeed = _damageNumberStats.MoveUpSpeed;
        _text = GetComponent<TextMeshPro>();
        StartCoroutine(MoveAndReturn(pool));
    }

    public void SetDamage(float damage)
    {
        _text.text = damage.ToString("0");
    }

    private IEnumerator MoveAndReturn(DamageNumbersHandler pool)
    {
        float timeLeft = _lifeTime;
        while (timeLeft > 0)
        {
            transform.position += Vector3.up * (_moveUpSpeed * Time.deltaTime);
            timeLeft -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        pool.ReturnToPool(this);
    }
}
