using Unity.VisualScripting;
using UnityEngine;
public abstract class Ability : MonoBehaviour
{
    [SerializeField] private GameObject _ability;
    [SerializeField] private Transform _spawnpoint;
    [SerializeField] private AbilityStats _stats;
    [SerializeField] CoolDownAbility _cooldown;

    protected abstract void InitAbility(GameObject instancedAbility, AbilityStats stats);
    protected void SetImage(Sprite icon)
    {
        _cooldown.SetAbilityImage(icon);
    }

    public void Use()
    {
        if (!_cooldown.IsAbilityCooldown)
        {
            _cooldown.StartCooldown(_stats.Cooldown);
            GameObject instancedAbility = Instantiate(_ability, _spawnpoint.position, Quaternion.identity);
            InitAbility(instancedAbility, _stats);
        }
    }
}
