using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _movementSpeed;
    private Vector2 _movementDirection;
    public Vector2 MoveDirection { set { _movementDirection = value; } }
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        _rb.velocity = _movementSpeed * _movementDirection;
    }
}

