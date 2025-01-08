using UnityEngine;
public class Ability : MonoBehaviour
{
    [SerializeField] private GameObject _ability;
    [SerializeField] private Transform _spawnpoint;
    [SerializeField] protected AbilityStats _stats;
    protected float _damage;
    protected float _lifetime;
    protected float _speed;

    private void Start()
    {
        SetAbilityStats();
    }
    public virtual void Use()
    {
        GameObject instancedAbility = Instantiate(_ability, _spawnpoint.position, Quaternion.identity);
        InitAbility(instancedAbility);
    }

    protected virtual void InitAbility(GameObject instancedAbility)
    {

    }
    
    protected virtual void SetAbilityStats()
    {
        _damage = _stats.Damage;
        _lifetime = _stats.Lifetime;
        _speed = _stats.Speed;
    }
}
