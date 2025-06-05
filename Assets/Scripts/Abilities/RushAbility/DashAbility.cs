using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class DashAbility : Ability
{
    [SerializeField] private Camera _camera;
    private Rigidbody2D _rb;
    private Player _player;

    private void Awake()
    {
        _rb = GetComponentInParent<Rigidbody2D>();
        _player = GetComponentInParent<Player>();
    }

    protected override void InitAbility()
    {
        var dashAbilityStats = _stats as DashAbilityStats;
        StartCoroutine(Dash(dashAbilityStats.Distance, dashAbilityStats.Duration));
    }

    private IEnumerator Dash(float dashDistance, float dashDuration)
    {
        _player.SetCanMove(false);

        var cursorWorldPos = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        var direction = ((Vector2)cursorWorldPos - (Vector2)transform.position).normalized;

        var start = _rb.position;
        var end = start + direction * dashDistance;
        float elapsed = 0;

        while (elapsed < dashDuration)
        {
            _rb.MovePosition(Vector2.Lerp(start, end, elapsed / dashDuration));
            elapsed += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        _rb.MovePosition(end);
        _player.SetCanMove(true);
    }
}
