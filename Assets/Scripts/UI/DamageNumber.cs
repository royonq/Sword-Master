using System.Collections;
using UnityEngine;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    [SerializeField] private DamageNumberStats _damageNumberStats;

    private float _moveUpSpeed;
    private float _lifeTime;
    private TextMeshPro _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshPro>();
    }

    public void Init(DamageNumbersHandler pool)
    {
        StopAllCoroutines();

        _lifeTime = _damageNumberStats.LifeTime;
        _moveUpSpeed = _damageNumberStats.MoveUpSpeed;
        
        StartCoroutine(MoveAndReturn(pool));
    }

    public void SetDamage(float damage)
    {
        _text.text = damage.ToString("0");
    }

    private IEnumerator MoveAndReturn(DamageNumbersHandler pool)
    {
        var timeLeft = _lifeTime;
        while (timeLeft > 0)
        {
            transform.position += Vector3.up * (_moveUpSpeed * Time.deltaTime);
            timeLeft -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        pool.ReturnToPool(this);
    }
}