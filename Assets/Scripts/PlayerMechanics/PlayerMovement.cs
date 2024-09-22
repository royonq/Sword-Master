using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float movementSpeed;
    private Vector2 movementDirection;
    public Vector2 MoveDirection { set { movementDirection = value; } }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        rb.velocity = movementSpeed * movementDirection;
    }
}

