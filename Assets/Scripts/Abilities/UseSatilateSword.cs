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
            StopAllCoroutines();
            StartCoroutine(_cooldown.Cooldown());
            Instantiate(_sword, _playerTracker.position, _playerTracker.rotation, _playerTracker);
        }    
    }
}
