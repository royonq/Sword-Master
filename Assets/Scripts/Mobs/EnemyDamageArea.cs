using System.Collections;
using UnityEngine;

public class EnemyDamageArea : MonoBehaviour
{
    private Collider2D _collider2D;
    private float _damage;

    public float Damage
    {
        set => _damage = value;
    }

    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Gate"))
        {
            other.GetComponent<Damageable>().TakeDamage(_damage);
        }
    }

    public IEnumerator Attack()
    {
        _collider2D.enabled = true;
        yield return null;
        _collider2D.enabled = false;
    }

    public void FlipDamageArea(SpriteRenderer spriteRenderer)
    {

        transform.localPosition = spriteRenderer.flipX
            ? new Vector3(-Mathf.Abs(transform.localPosition.x), transform.localPosition.y,
                transform.localPosition.z)
            : new Vector3(Mathf.Abs(transform.localPosition.x), transform.localPosition.y,
                transform.localPosition.z);
    }
}
