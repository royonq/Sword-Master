using UnityEngine;

public class Sword : MonoBehaviour
{
    private float _damage;
    public float Damage { set { _damage = value; } }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
           
        }
    }

}
