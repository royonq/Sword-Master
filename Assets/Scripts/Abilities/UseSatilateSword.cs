using UnityEngine;

public class UseSatilateSword : MonoBehaviour
{
    [SerializeField] private AbilitySateliteSword _abilitySateliteSword;
    [SerializeField] private GameObject _sword;
    [SerializeField] private Transform _playerTracker;
    [SerializeField] private CoolDownAbility _cooldown;
    private void Start()
    {
        _cooldown.SetAbilityImage(_abilitySateliteSword.AbilityIcon);
    }
    public void InstantiateSword()
    {
        if (!_cooldown.IsAbilityCooldown)
        {
            _cooldown.StartCooldown(_abilitySateliteSword.TimeCooldown);
            GameObject newSword = Instantiate(_sword, _playerTracker.position, _playerTracker.rotation, _playerTracker);
            newSword.GetComponent<SatelliteSword>().SetSwordStats(_abilitySateliteSword.Damage, _abilitySateliteSword.RotationSpeed);
        }
    }

}
