using UnityEngine;

public class SwordProjectile : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _damage;
    private float _speed;
    private float _lifeTime;

    public void Init(SwordProjectileStats stats)
    {
        _damage = stats.Damage;
        _speed = stats.Speed;
        _lifeTime = stats.Lifetime;

        LaunchProjectile();
    }

    private void LaunchProjectile()
    {
        _rb = GetComponent<Rigidbody2D>();

        _rb.velocity = _speed * transform.right;

        Destroy(gameObject, _lifeTime);
    }
}
