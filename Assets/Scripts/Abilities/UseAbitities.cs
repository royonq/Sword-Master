using UnityEngine;

public class UseAbitities : MonoBehaviour
{
    [SerializeField] private GameObject _sword;
    [SerializeField] private Transform _playerTracker;
    [SerializeField] private float _instantiateRadius;
    public void InstantiateSword()
    {
        Instantiate(_sword, _playerTracker.position, _playerTracker.rotation, _playerTracker);
    }
}
