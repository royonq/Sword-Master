using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Rigidbody2D _rb;
    [SerializeField] private float _speed;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Follow();
    }

    public void Follow()
    {
        if (_target == null)
        {
            return;
        }
        Vector2 direction = _target.position - transform.position;
        _rb.velocity = _speed * direction;
    }
}
