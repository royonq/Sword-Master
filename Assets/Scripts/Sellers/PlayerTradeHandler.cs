using UnityEngine;

public class PlayerTradeHandler : MonoBehaviour
{
    private GameObject _currentTradePannel;

    public GameObject CurrentTradePannel
    {
        set => _currentTradePannel = value;
    }

    private bool _isPlayerOnTradeZone;

    public bool IsPlayerOnTradeZone
    {
        set => _isPlayerOnTradeZone = value;
    }

private bool _isTradePannelOpen;
    
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
        if (!_isPlayerOnTradeZone)
        {
            return;
        }
        _isTradePannelOpen = !_isTradePannelOpen;
        _currentTradePannel.SetActive(_isTradePannelOpen);
    }
    
    
}
