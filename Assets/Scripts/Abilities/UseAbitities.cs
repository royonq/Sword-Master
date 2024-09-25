using UnityEngine;

public class UseAbitities : MonoBehaviour
{
    [SerializeField] private GameObject _sword;
    [SerializeField] private float _instantiateRadius;
    public void InstantiateSword()
    {
        Instantiate(_sword, transform.position + Vector3.right * _instantiateRadius, transform.rotation);
    }
}
