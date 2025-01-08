using UnityEngine;
public class Ability : MonoBehaviour
{
    [SerializeField] private GameObject _ability;
    [SerializeField] private Transform _spawnpoint;


    public virtual void Use()
    {
        GameObject instancedAbility = Instantiate(_ability, _spawnpoint.position, Quaternion.identity);
        InitAbility(instancedAbility);
    }

    protected virtual void InitAbility(GameObject instancedAbility)
    {

    }
}
