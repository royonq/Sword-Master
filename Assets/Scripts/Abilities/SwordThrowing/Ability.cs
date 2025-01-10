using UnityEngine;
public class Ability : MonoBehaviour
{
    [SerializeField] private GameObject _ability;
    [SerializeField] private Transform _spawnpoint;
    [SerializeField] private AbilityStats _stats;
    public virtual void Use()
    {
        GameObject instancedAbility = Instantiate(_ability, _spawnpoint.position, Quaternion.identity);
        InitAbility(instancedAbility,_stats);
    }

    protected virtual void InitAbility(GameObject instancedAbility,AbilityStats stats)
    {

    }
}
