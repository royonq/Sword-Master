using UnityEngine;
[CreateAssetMenu(fileName = "NewAbility", menuName = "Ability")]
public class AbilityStats : ScriptableObject
{
    [SerializeField] protected float _damage;
    public float Damage { get { return _damage; } }

    [SerializeField] protected float _lifetime;
    public float Lifetime { get { return _lifetime; } }

    [SerializeField] protected float _speed;
    public float Speed { get { return _speed; } }
}
