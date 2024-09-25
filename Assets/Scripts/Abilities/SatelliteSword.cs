using UnityEngine;

public class SatelliteSword : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    private Rigidbody _rb;
    private Vector2 _swordMoveDirection;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
}
