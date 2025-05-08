using System.Collections;
using UnityEngine;

public class BowAttack : MonoBehaviour, IAttack
{
    [SerializeField] private BowAttackStats _bowAttackStats;
    private float _arrowSpeed;
    private float _timeToDestroy;
    private float _damage;
    private Vector2 _arrowDirection;
    
    private void Start()
    {
        SetStats();
    }

    private void SetStats()
    {
        _arrowSpeed = _bowAttackStats.Speed;
        _timeToDestroy = _bowAttackStats.TimeToDestroy;
        _damage = _bowAttackStats.Damage;
    }

    public IEnumerator Attack()
    {
        yield return null;

        Vector2 direction = GetComponent<Enemy>().Direction;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        var arrow = Instantiate(_bowAttackStats.BowArrow, transform.position, rotation);

        arrow.GetComponent<Arrow>().Init(_arrowSpeed, _damage, _timeToDestroy);
    }
}