using System.Collections;
using UnityEngine;

public class SwordProjectile : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] float _speed;

    public void Init(float lifeTime)
    {
        _rb = GetComponent<Rigidbody2D>();

        _rb.velocity = _speed * transform.right;

        Destroy(gameObject, lifeTime);
    }
}
