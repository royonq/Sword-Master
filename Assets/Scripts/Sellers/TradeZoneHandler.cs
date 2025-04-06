using UnityEngine;

public class TradeZoneHandler : MonoBehaviour
{
    private GameObject _currentTradePannel;
    
    private bool _isPlayerOnTradeZone;
    
    
    public void EnterToTradeZone(GameObject tradePannel)
    {
        _currentTradePannel = tradePannel;
        _isPlayerOnTradeZone = true;
    }
    public void ExitTradeZone()
    {
        _isPlayerOnTradeZone = false;
        _currentTradePannel = null;
    }
    
    private void Awake()
    {
        PlayerInput.OnTradePannelSetActive += OpenTradePannel;
    }

    private void OnDestroy()
    {
        PlayerInput.OnTradePannelSetActive -= OpenTradePannel;
    }
    
    private void OpenTradePannel()
    {
        if (_isPlayerOnTradeZone)
        {
            _currentTradePannel.SetActive(!_currentTradePannel.activeSelf);
        }
    }
}
