using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class DashAbility : Ability
{ 
    [SerializeField] private DashAbilityStats _dashAbilityStats;
    private Vector2 _direction;
    
    private void GetDirectionToCursor()
    {
        var cursorWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        _direction = ((Vector2)cursorWorldPos - (Vector2)transform.position).normalized;
    }
    
    protected override void InitInstanceAbility()
    {
        StartCoroutine(Dash(_dashAbilityStats.DashDistance, _dashAbilityStats.DashDuration));
        StartCoroutine(Cooldown(_dashAbilityStats.DashDuration));
    }

    private IEnumerator Dash(float dashDistance, float dashDuration)
    {
        var playerRb = GetComponentInParent<Rigidbody2D>();
        var collider = GetComponentInParent<Collider2D>();
        GetDirectionToCursor();
        collider.enabled = false;

        Vector2 startPosition = playerRb.position;
        Vector2 endPosition = startPosition + _direction * dashDistance;
        float elapsed = 0f;

        while (elapsed < dashDuration)
        {
            playerRb.MovePosition(Vector2.Lerp(startPosition, endPosition, elapsed / dashDuration));
            elapsed += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        playerRb.MovePosition(endPosition);
        collider.enabled = true;
    }
    
}
