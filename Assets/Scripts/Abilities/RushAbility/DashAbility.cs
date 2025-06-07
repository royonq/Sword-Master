using UnityEngine;
using System.Collections;
using TMPro.Examples;
using UnityEngine.InputSystem;

public class DashAbility : Ability
{
    [SerializeField] private Camera _camera;
    private DashAbilityStats _dashAbilityStats;
    private Rigidbody2D _rb;
    private Player _player;
    
    private float _slowDuration;
    private float _slowFactor;
    private float _slowRadius;
    
    private TrailRenderer _trail;

    private void Awake()
    {
        _rb = GetComponentInParent<Rigidbody2D>();
        _player = GetComponentInParent<Player>();
        _trail = GetComponentInParent<TrailRenderer>();
    }

    protected override void InitAbility()
    {
        _dashAbilityStats = _stats as DashAbilityStats;
        _slowDuration = _dashAbilityStats.SlowDuration;
        _slowFactor = _dashAbilityStats.SlowFactor;
        _slowRadius = _dashAbilityStats.SlowRadius;
        
        StartCoroutine(Dash(_dashAbilityStats.Distance, _dashAbilityStats.Duration));
    }

    private IEnumerator Dash(float dashDistance, float dashDuration)
    {
        _player.SetCanMove(false);
        _player.SetInvulnerable(true);
        _trail.enabled = true;
        var cursorWorldPos = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        var direction = ((Vector2)cursorWorldPos - (Vector2)transform.position).normalized;

        var start = _rb.position;
        var end = start + direction * dashDistance;
        
        float elapsed = 0;
        while (elapsed < dashDuration)
        {
            var cerrentPosition = Vector2.Lerp(start, end, elapsed / dashDuration);
            _rb.MovePosition(cerrentPosition);
            
            elapsed += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        _rb.MovePosition(end);
        
        HitEnemiesOnLine(start, end);
        _player.SetCanMove(true);
        _player.SetInvulnerable(false);
        _trail.enabled = false;
    }
    
    private void HitEnemiesOnLine(Vector2 start, Vector2 end)
    {
        var direction = (end - start).normalized;
        float length = Vector2.Distance(start, end);
        
        var hits = Physics2D.RaycastAll(start, direction,
            length, LayerMask.GetMask("Enemy"));

        foreach (var hit in hits)
        {
            var enemy = hit.collider.GetComponent<Enemy>();

            var distance = CalculateDistanceToLine(start, end, enemy.transform.position);
            if (distance <= _slowRadius)
            {
                enemy.ApplySlow(_slowFactor,_slowDuration);
            }
        }
    }
    
    private float CalculateDistanceToLine(Vector2 segmentStart, Vector2 segmentEnd, Vector2 point)
    {
        var segment = segmentEnd - segmentStart;
        float projection = Vector2.Dot(point - segmentStart, segment) / segment.sqrMagnitude;
        projection = Mathf.Clamp01(projection);
        var closestPoint = segmentStart + segment * projection;
        return Vector2.Distance(point, closestPoint);
    }
}
