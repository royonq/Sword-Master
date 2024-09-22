using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    private int _moneyCount;
    private Coin _coin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MONEY"))
        {
            _coin = collision.GetComponent<Coin>();
            MoneyPickUp(_coin.Cost);
            Destroy(collision.gameObject);
        }
    }
    private void MoneyPickUp(int pickedMoney)
    {
        _moneyCount += pickedMoney;
        Debug.Log(_moneyCount);
    }
}
