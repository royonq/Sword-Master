using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movementDirection;
    private Rigidbody2D rb;
    [SerializeField] private float movementSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Movement()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    public void MovePlayer()
    {
        rb.velocity = movementSpeed * movementDirection;
    }
}

