using UnityEngine;
[CreateAssetMenu(fileName = "NewEnemy", menuName = "Enemy")]
public class EnemyStats : ScriptableObject
{
    [SerializeField] private float _health;
    public float Health { get { return _health; }  }

    [SerializeField] private float _speed;
    public float Speed { get { return _speed; } }

    [SerializeField] private float _damage;
    public float Damage { get { return _damage; } }
}
