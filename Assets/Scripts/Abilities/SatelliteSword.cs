using UnityEngine;

public class SatelliteSword : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private void FixedUpdate()
    {
        RotateAroundPlayer();
    }

    private void RotateAroundPlayer()
    {
        transform.Rotate(Vector3.forward * _rotationSpeed * Time.fixedDeltaTime);
    }
}