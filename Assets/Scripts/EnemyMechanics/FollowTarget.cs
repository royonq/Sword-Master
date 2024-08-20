using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform Traget;
    public Rigidbody2D rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Follow();
    }

    public void Follow()
    {
        Vector2 direction = Traget.position - transform.position;
        rb.velocity = speed * direction;
    }
}
