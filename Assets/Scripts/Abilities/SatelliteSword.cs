using UnityEngine;

public class SatelliteSword : MonoBehaviour
{
    [SerializeField] private Sword _sword;
    private float _rotationSpeed;

    private void FixedUpdate()
    {
        RotateAroundPlayer();
    }

    private void RotateAroundPlayer()
    {
        transform.Rotate(_rotationSpeed * Time.fixedDeltaTime * Vector3.forward);
    }

    public void SetSwordStats(float damage, float rotationSpeed)
    {
        _rotationSpeed = rotationSpeed;
        _sword.Damage = damage;
    }
}