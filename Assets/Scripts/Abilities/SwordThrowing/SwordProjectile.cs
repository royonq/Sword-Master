using UnityEngine;

public class SwordProjectile : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private SwordProjectileStats _stats;

    public void Init(float lifeTime)
    {
        _rb = GetComponent<Rigidbody2D>();

        _rb.velocity = _stats.Speed * transform.right;

        Destroy(gameObject, lifeTime);
    }
}
