using UnityEngine;
public abstract class Ability : MonoBehaviour
{
    [SerializeField] private GameObject _ability;
    [SerializeField] private Transform _spawnpoint;
    [SerializeField] private AbilityStats _stats;

    protected abstract void InitAbility(GameObject instancedAbility, AbilityStats stats);

    public void Use()
    {
        GameObject instancedAbility = Instantiate(_ability, _spawnpoint.position, Quaternion.identity);
        InitAbility(instancedAbility, _stats);
    }
}
