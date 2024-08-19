using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform playerPosition;
    public Rigidbody2D rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        Vector2 direction = playerPosition.position - transform.position;
        rb.velocity = speed * Time.deltaTime * direction;
    }
}
