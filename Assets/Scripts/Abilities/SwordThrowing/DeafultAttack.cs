using UnityEngine;
public class DeafultAttack : MonoBehaviour
{
    [SerializeField] private GameObject _sword;
    [SerializeField] private Transform _spawnpoint;
    [SerializeField] private float _swordLifeTime;

    public void Throw()
    {
        Instantiate(_sword, _spawnpoint.position, Quaternion.identity)
                            .GetComponent<SwordProjectile>().Move(_swordLifeTime);    
    }
}
