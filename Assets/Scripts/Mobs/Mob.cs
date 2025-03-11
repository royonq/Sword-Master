using UnityEngine;

public abstract class Mob : Damageable
{
    protected float _damage;
    private float _attackSpeed;

    private Rigidbody2D _rb;
    private float _movementSpeed;
    private Vector2 _movementDirection;
    public Vector2 MoveDirection { set => _movementDirection = value; }


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    protected override void SetStats()
    {
        base.SetStats();
        var mobStats = _damagableStats as MobStats;

        _movementSpeed = mobStats.MovementSpeed;
        _attackSpeed = mobStats.AttackSpeed;
        _damage = mobStats.Damage;
    }

    public virtual void Move(Vector2 direction)
    {
        _rb.velocity = _movementSpeed * direction;
    }

    private void Heal()
    {

    }

    private void Damage()
    {

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
