using System.Collections;
using UnityEngine;

public class SwordProjectile : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] float _speed;


    public IEnumerator Throw(float lifeTime)
    {
        while (lifeTime > 0)
        {
            yield return null;

            Move(transform.right);

            lifeTime--;

            Destroy(gameObject);
        }
    }

    public void Move(Vector2 direction)
    {
        _rb.velocity = _speed * direction;
    }
}
