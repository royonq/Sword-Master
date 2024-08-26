using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform Traget;
    private Rigidbody2D rb;
    [SerializeField] private float speed;

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
