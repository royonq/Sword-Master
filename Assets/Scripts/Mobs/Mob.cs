using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField] protected MobStats _mobStats;

    private float _health;
    private float _damage;
    private float _attackSpeed;

    protected Rigidbody2D _rb;
    protected float _movementSpeed;


    

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
