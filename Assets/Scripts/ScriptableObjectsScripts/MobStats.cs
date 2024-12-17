using UnityEngine;
[CreateAssetMenu(fileName = "NewMob", menuName = "Mob")]

public class MobStats : ScriptableObject
{
    [SerializeField] protected float _health;
    public float Health { get { return _health; } }


    [SerializeField] protected float _movementSpeed;
    public float MovementSpeed { get { return _movementSpeed; } }


    [SerializeField] protected float _damage;
    public float Damage { get { return _damage; } }


    [SerializeField] protected float _attackSpeed;
    public float AttackSpeed { get { return _attackSpeed; } }
}
