using UnityEngine;

public class TradePannelChecker : MonoBehaviour
{
    [SerializeField] private GameObject _tradePannel;
    private PlayerTradeHandler _playerTradeHandler;

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
          _playerTradeHandler = other.gameObject.GetComponent<PlayerTradeHandler>();
          _playerTradeHandler.IsPlayerOnTradeZone = true;
          _playerTradeHandler.CurrentTradePannel = _tradePannel;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerTradeHandler.IsPlayerOnTradeZone = false;
            _playerTradeHandler.CurrentTradePannel = null;
        }
    }
}
