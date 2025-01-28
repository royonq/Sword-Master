using UnityEngine;

public abstract class Mob : MonoBehaviour
{
    [SerializeField] protected MobStats _mobStats;

    private float _health;
    private float _damage;
    private float _attackSpeed;

    protected Rigidbody2D _rb;
    protected float _movementSpeed;
    private Vector2 _movementDirection;
    public Vector2 MoveDirection { set { _movementDirection = value; } }

    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        SetStats();
    }

    protected virtual void SetStats()
    {
        _health = _mobStats.Health;
        _movementSpeed = _mobStats.MovementSpeed;
        _attackSpeed = _mobStats.AttackSpeed;
        _damage = _mobStats.Damage;
    }

    public void Move(Vector2 direction)
    {
        _rb.velocity = _movementSpeed * direction;
    }

    private void Heal()
    {

    }

    private void Damage()
    {

    }

    public void TakeDamage(float recivedDamage)
    {
        _health -= recivedDamage;
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void ItemPickUp()
    {

    }


    private void AplyStun()
    {

    }

    private void ReceiveStun()
    {
       
    }

}
