using UnityEngine;

public class Trader : MonoBehaviour
{
    [SerializeField] private GameObject _tradePannel;

    public void OpenTradePannel()
    {
        _tradePannel.SetActive(!_tradePannel.activeSelf);
    }
}