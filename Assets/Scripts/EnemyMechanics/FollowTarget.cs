using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private SpawnEnemies _spawnEnemies;
    private Rigidbody2D _rb;
    [SerializeField] private float _speed;

    private void Start()
    {
        _target = _spawnEnemies.PlayerPosition;
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
