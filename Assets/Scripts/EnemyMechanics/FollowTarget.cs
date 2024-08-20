using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
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
        Vector2 direction = target.position - transform.position;
        rb.velocity = speed * direction;
    }
}
