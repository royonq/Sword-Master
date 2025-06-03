using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class DashAbility : Ability
{
    [SerializeField] private Camera _camera;
    private Vector2 _direction;
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponentInParent<Rigidbody2D>();
    }

    protected override void InitAbility()
    {
        var dashAbilityStats = _stats as DashAbilityStats;
        StartCoroutine(Dash(dashAbilityStats.Distance, dashAbilityStats.Duration));
    }

    private void GetDirectionToCursor()
    {
        var cursorWorldPos = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        _direction = ((Vector2)cursorWorldPos - (Vector2)transform.position).normalized;
    }

    private IEnumerator Dash(float dashDistance, float dashDuration)
    {
        _isAbilityUsing = true;
        GetDirectionToCursor();

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
        _isAbilityUsing = false;
    }
}
