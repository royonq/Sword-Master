using UnityEngine;

public abstract class Mob : Damageable
{ 
    private MobAnimations _mobAnimations;
    

    private Rigidbody2D _rb;
    private float _deafultMovementSpeed;
    private bool _canMove = true;
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

    public void SetCanMove(bool value)
    {
        _canMove = value;
    }

    public void Move(Vector2 direction)
    {
        if (!_canMove)
        {
            return;
        }
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
