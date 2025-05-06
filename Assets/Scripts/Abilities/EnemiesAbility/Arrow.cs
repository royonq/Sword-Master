using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private ArrowStats _arrowStats;
    private Rigidbody2D _rb;
    private float _speed;
    private float _damage;
    
    private void Init()
    {
        _speed = _arrowStats.Speed;
        _damage = _arrowStats.Damage;
    }
    public void LaunchArrow()
    {
        Init();
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = _speed * transform.right;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.GetComponent<Mob>().TakeDamage(_damage);

            Destroy(gameObject);
        }
    }
}