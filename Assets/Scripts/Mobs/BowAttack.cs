using System.Collections;
using UnityEngine;

public class BowAttack : MonoBehaviour, IAttack
{
    [SerializeField] private BowAttackStats _bowAttackStats;
    private float cooldown;
    private Transform _target;

    private void Start()
    {
        SetStats();
    }

    private void SetStats()
    {
        cooldown = _bowAttackStats.AttackCooldown;
        _target = GetComponent<Enemy>().GetTarget();
    }

    public IEnumerator Attack()
    {
        yield return new WaitForSeconds(cooldown);

        Vector2 direction = _target.position - transform.position;
        var arrow = Instantiate(_bowAttackStats.BowArrow, transform.position, Quaternion.identity);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrow.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        arrow.GetComponent<Arrow>().LaunchArrow();
    }
}