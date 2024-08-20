using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 movementDirection;
    public Rigidbody2D rb;
    public float movementSpeed;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        rb.velocity = movementSpeed * movementDirection;
    }
}

