using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    public static event Action<DamageNumber> OnShowDamage;
    [SerializeField] private DamageNumberStats _damageNumberStats;

    private float _moveUpSpeed;
    private float _lifeTime;
    private TextMeshPro _text;


    public void Init(float damage, Vector3 position)
    {
        _lifeTime = _damageNumberStats.LifeTime;
        _moveUpSpeed = _damageNumberStats.MoveUpSpeed;
        _text = GetComponent<TextMeshPro>();
        _text.text = damage.ToString("0");
        transform.position = position;
        StartCoroutine(MoveAndReturn());
    }

    private IEnumerator MoveAndReturn()
    {
        while (_lifeTime > 0)
        {
            transform.position += Vector3.up * (_moveUpSpeed * Time.fixedDeltaTime);
            _lifeTime -= Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        OnShowDamage?.Invoke(this);
    }
}
