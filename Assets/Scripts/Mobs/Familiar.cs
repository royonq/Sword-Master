using UnityEngine;

public class Familiar : MonoBehaviour
{  
    [SerializeField] private FamiliarStats _familiarStats;
    private Transform _playerAnchor;
    private Rigidbody2D _rb;
    private Vector2 _direction;

    private float _speed;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _speed = _familiarStats.FamiliarSpeed;
    }

    public void SetChaseTarget(Transform target)
    {
        _playerAnchor = target;
    }

    private void ChasePlayer()
    {
        _direction = (_playerAnchor.position - transform.position).normalized;
        _rb.velocity = _speed * _direction;
    }

    private void FixedUpdate()
    {
        ChasePlayer();
    }
}