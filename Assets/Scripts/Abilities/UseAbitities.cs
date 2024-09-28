using UnityEngine;

public class UseAbitities : MonoBehaviour
{
    [SerializeField] private GameObject _sword;
    [SerializeField] private Transform _playerTracker;
    public void InstantiateSword()
    {
        Instantiate(_sword, _playerTracker.position, _playerTracker.rotation, _playerTracker);
    }
}
