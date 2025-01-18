using UnityEngine;

public class SatelliteSword : Projectile
{

    [SerializeField] private Projectile _sword;
    private float _rotationSpeed;
    private void FixedUpdate()
    {
        RotateAroundPlayer();
    }

    public override void Init(AbilityStats stats)
    {
        base.Init(stats);
        var _sateliteSwordStats = stats as SateliteSwordStats;

        _rotationSpeed = _sateliteSwordStats.RotationSpeed;
    }

    private void RotateAroundPlayer()
    {
        transform.Rotate(_rotationSpeed * Time.fixedDeltaTime * Vector3.forward);
    }
}
