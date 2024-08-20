using UnityEngine;

public class Pursuit : MonoBehaviour
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
        Following();
    }
    public void Following()
    {
        Vector2 direction = target.position - transform.position;
        rb.velocity = speed *  direction;
    }
}
