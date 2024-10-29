using UnityEngine;

public class SatelliteSword : MonoBehaviour
{
    private SwordAbilityManager _swordAbilityManager;
    private float _rotationSpeed;

    private void FixedUpdate()
    {
        _swordAbilityManager = GetComponent<SwordAbilityManager>();
        _rotationSpeed = _swordAbilityManager.RotationSpeed;
        RotateAroundPlayer();
    }

    private void RotateAroundPlayer()
    {
        transform.Rotate(_rotationSpeed * Time.fixedDeltaTime * Vector3.forward);
    }
}