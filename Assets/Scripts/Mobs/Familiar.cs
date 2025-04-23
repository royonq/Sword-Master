using UnityEngine;

public class Familiar : MonoBehaviour
{
    [SerializeField] private FamiliarData _familiarData;
    private Transform _playerTransform;
    private Rigidbody2D _rb;
    private Vector2 _direction;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(Transform target)
    {
        _playerTransform = target;
    }

    private void FollowToPlayer(Vector2 direction)
    {
        _rb.velocity = _familiarData.FamiliarSpeed * direction;
    }

    private void FixedUpdate()
    {
        _direction = _playerTransform.position - transform.position;
        FollowToPlayer(_direction.normalized);
    }
}