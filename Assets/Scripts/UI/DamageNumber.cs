using System.Collections;
using UnityEngine;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    [SerializeField] private DamageNumberStats _damageNumberStats;
    
    private  float _moveUpSpeed;
    private  float _lifeTime;
    
    [SerializeField] private TextMeshPro _text;

    private void Awake()
    {
        Init();
        StartCoroutine(MoveAndDestroy());
    }

    private void Init()
    {
        _lifeTime = _damageNumberStats.LifeTime;
        _moveUpSpeed = _damageNumberStats.MoveUpSpeed;
    }
    
    public void SetDamage(float damage)
    {
        _text.text = damage.ToString("0");
    }

    private IEnumerator MoveAndDestroy()
    {
        while (_lifeTime > 0)
        {
            transform.position += Vector3.up * (_moveUpSpeed * Time.fixedDeltaTime);
            _lifeTime -= Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        Destroy(gameObject);
    }
}
