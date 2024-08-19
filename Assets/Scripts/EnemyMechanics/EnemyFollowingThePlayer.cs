using UnityEngine;

public class EnemyFollowingThePlayer : MonoBehaviour
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
        TargetThePlayer();
    }
    public void TargetThePlayer()
    {
        Vector2 direction = (playerPosition.position - transform.position);
        rb.velocity = speed * Time.deltaTime * direction;
    }
}
