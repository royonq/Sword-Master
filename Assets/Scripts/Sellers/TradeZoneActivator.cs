using UnityEngine;

public class TradeZoneActivator : MonoBehaviour
{
    [SerializeField] private GameObject _tradePannel;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           other.gameObject.GetComponent<TradeZoneHandler>().EnterToTradeZone(_tradePannel);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<TradeZoneHandler>().ExitTradeZone();
        }
    }
}
