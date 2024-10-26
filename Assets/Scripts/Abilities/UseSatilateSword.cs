using UnityEngine;

public class UseSatilateSword : MonoBehaviour
{
    [SerializeField] private GameObject _sword;
    [SerializeField] private Transform _playerTracker;
    [SerializeField] private CoolDown _cooldown;
    public void InstantiateSword()
    {
        if (!_cooldown.IsCooldown)
        {
            _cooldown.StartCooldown();
            Instantiate(_sword, _playerTracker.position, _playerTracker.rotation, _playerTracker);
        }    
    }
}
