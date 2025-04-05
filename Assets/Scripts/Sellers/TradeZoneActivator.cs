using UnityEngine;

public class TradeZoneActivator : MonoBehaviour
{
    [SerializeField] private GameObject _tradePannel;
    private TradeZoneHandler tradeZoneHandler;

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
          tradeZoneHandler = other.gameObject.GetComponent<TradeZoneHandler>();
          tradeZoneHandler.EnterToTradeZone(_tradePannel);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            tradeZoneHandler.ExitTradeZone();
        }
    }
}
