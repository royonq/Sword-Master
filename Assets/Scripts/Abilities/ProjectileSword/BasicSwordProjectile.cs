using UnityEngine;
using UnityEngine.InputSystem;

public class BasicSwordProjectile : SwordProjectile
{
    public override void Init(float damage, float speed, float lifeTime, bool isUpgraded, float damageModifier)
    {
        base.Init(damage, speed, lifeTime, isUpgraded, damageModifier);
        RotateTowardsCrosshair();
        LaunchProjectile();
    }

    private void RotateTowardsCrosshair()
    {
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3 direction = cursorPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
