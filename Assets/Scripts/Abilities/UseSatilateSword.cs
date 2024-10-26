using UnityEngine;

public class UseSatilateSword : MonoBehaviour
{
    [SerializeField] private GameObject _sword;
    [SerializeField] private Transform _playerTracker;
    [SerializeField] private CoolDownAbility _cooldown;
    public void InstantiateSword()
    {
        if (!_cooldown.IsAbilityCooldown)
        {
            _cooldown.StartCooldown();
            Instantiate(_sword, _playerTracker.position, _playerTracker.rotation, _playerTracker);
        }    
    }
}
