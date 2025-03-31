using UnityEngine;

public abstract class Mob : Damageable
{ 
    private MobAnimations _mobAnimations;
    
    protected float _damage;

    private Rigidbody2D _rb;
    private float _movementSpeed;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _mobAnimations = GetComponentInChildren<MobAnimations>();
    }

    protected override void SetStats()
    {
        base.SetStats();
        var mobStats = _damagableStats as MobStats;

        _movementSpeed = mobStats.MovementSpeed;
        _damage = mobStats.Damage;
    }

    public void Move(Vector2 direction)
    {
        _rb.velocity = _movementSpeed * direction;
        _mobAnimations.MoveIdleAnimation(direction);
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
