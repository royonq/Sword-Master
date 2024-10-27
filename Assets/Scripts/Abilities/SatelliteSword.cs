using UnityEngine;

public class SatelliteSword : MonoBehaviour
{
    [SerializeField] private AbilitySateliteSword _abilitySateliteSword;
     private float _rotationSpeed;

    private void FixedUpdate()
    {
        _rotationSpeed = _abilitySateliteSword.RotationSpeed;
        RotateAroundPlayer();
    }

    private void RotateAroundPlayer()
    {
        transform.Rotate(Vector3.forward * _rotationSpeed * Time.fixedDeltaTime);
    }
}