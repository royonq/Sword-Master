using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    private Player _player;
    private void Start()
    {
        _player = GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Money"))
        {
            var coin = collision.GetComponent<Coin>();
            _player.MoneyPickUp(coin.Cost);
            Destroy(collision.gameObject);
        }
    }
}
