using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowSword : MonoBehaviour
{
    [SerializeField] private GameObject _sword;
    [SerializeField] private Transform _spawnpoint;
    [SerializeField] private float _swordLifeTime;

    public void OnThrow(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject newSword = Instantiate(_sword, _spawnpoint.position, Quaternion.identity);

            SwordProjectile swordProjectile = newSword.GetComponent<SwordProjectile>();

            StartCoroutine(swordProjectile.Throw(_swordLifeTime));
        }
    }
}
