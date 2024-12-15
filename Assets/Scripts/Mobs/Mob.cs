using UnityEngine;

public class Mob : MonoBehaviour
{
    private float _health;
    private float _damage;
    private float _attackSpeed;

    private Rigidbody2D _rb;
    private float _movementSpeed;
    private Vector2 _movementDirection;
    public Vector2 MoveDirection { set { _movementDirection = value; } }
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }

    protected virtual void SetStats(MobStats mobStats)
    {
        _health = mobStats.Health;
        _movementSpeed = mobStats.MovementSpeed;
        _attackSpeed = mobStats.AttackSpeed;
        _damage = mobStats.Damage;
    }

    private void Move()
    {
        _rb.velocity = _movementSpeed * _movementDirection;
    }

    private void Heal()
    {

    }

    private void Damage()
    {

    }

    private void TakeDamage(float recivedDamage)
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

    public void UseAbility()
    {

    }

    private void AplyStun()
    {

    }

    private void ReceiveStun()
    {
       
    }

}
