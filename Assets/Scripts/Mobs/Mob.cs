using UnityEngine;

public abstract class Mob : Damageable
{ 
    private MobAnimations _mobAnimations;
    

    private Rigidbody2D _rb;
    private float _deafultMovementSpeed;
    protected virtual float ModifierSpeed => _deafultMovementSpeed;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _mobAnimations = GetComponentInChildren<MobAnimations>();
    }

    protected override void SetStats()
    {
        base.SetStats();
        var mobStats = _damageableStats as MobStats;

        _deafultMovementSpeed = mobStats.MovementSpeed;
    }

    public void Move(Vector2 direction)
    {
        _rb.velocity = ModifierSpeed * direction;
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
