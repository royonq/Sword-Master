using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileRotate : Projectile
{
    public override void Init(AbilityStats stats)
    {
        base.Init(stats);
        RotateTowardsCrosshair();
    }

    public void RotateTowardsCrosshair()
    {
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3 direction = (cursorPosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
