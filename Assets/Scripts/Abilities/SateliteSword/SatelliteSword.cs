using UnityEngine;

public class SatelliteSword : Sword
{

    [SerializeField] private Sword _sword;
    private float _rotationSpeed;
    private void FixedUpdate()
    {
        RotateAroundPlayer();
    }

    public override void Init(AbilityStats stats)
    {
        var _sateliteSwordStats = stats as SateliteSwordStats;
        base.Init(_sateliteSwordStats);

        _rotationSpeed = _sateliteSwordStats.RotationSpeed;
    }

    private void RotateAroundPlayer()
    {
        transform.Rotate(_rotationSpeed * Time.fixedDeltaTime * Vector3.forward);
    }
}
