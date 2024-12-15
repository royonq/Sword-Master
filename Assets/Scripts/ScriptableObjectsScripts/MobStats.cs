using UnityEngine;
[CreateAssetMenu(fileName = "NewMob", menuName = "Mob")]
public class MobStats : ScriptableObject
{
    [SerializeField] private float _health;
    public float Health { get { return _health; } }


    [SerializeField] private float _movementSpeed;
    public float MovementSpeed { get { return _movementSpeed; } }


    [SerializeField] private float _damage;
    public float Damage { get { return _damage; } }


    [SerializeField] private float _attackSpeed;
    public float AttackSpeed { get { return _attackSpeed; } }
}
