using System;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    public static event Action<int> OnPickUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Money"))
        {
            var coin = collision.GetComponent<Coin>();
            OnPickUp?.Invoke(coin.Cost);
            Destroy(collision.gameObject);
        }
    }
}
