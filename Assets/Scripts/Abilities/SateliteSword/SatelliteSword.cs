using UnityEngine;

public class SatelliteSword : Projectile
{
    private void FixedUpdate()
    {
        RotateAroundPlayer();
    }

    private void RotateAroundPlayer()
    {
        transform.Rotate(_speed * Time.fixedDeltaTime * Vector3.forward);
    }
}
