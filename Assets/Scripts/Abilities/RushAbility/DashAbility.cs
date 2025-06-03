using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class DashAbility : Ability
{
    private Vector2 _direction;
    private Rigidbody2D _rb;
    private Collider2D _col;

    private void Awake()
    {
        _rb = GetComponentInParent<Rigidbody2D>();
        _col = GetComponentInParent<Collider2D>();
    }

    protected override void InitAbility()
    {
        var dashAbilityStats = _stats as DashAbilityStats;
        StartCoroutine(Dash(dashAbilityStats.DashDistance, dashAbilityStats.DashDuration));
        base.InitAbility();
    }

    private void GetDirectionToCursor()
    {
        var cursorWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        _direction = ((Vector2)cursorWorldPos - (Vector2)transform.position).normalized;
    }

    private IEnumerator Dash(float dashDistance, float dashDuration)
    {
        GetDirectionToCursor();
        _col.enabled = false;

        var start = _rb.position;
        var end = start + _direction * dashDistance;
        float elapsed = 0;

        while (elapsed < dashDuration)
        {
            _rb.MovePosition(Vector2.Lerp(start, end, elapsed / dashDuration));
            elapsed += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        _rb.MovePosition(end);
        _col.enabled = true;
    }
}
