using UnityEngine;

[CreateAssetMenu(fileName = "NewWallet", menuName = "Data/EarnItems/Wallet")]
public class StartMoneyData : ScriptableObject
{
    [SerializeField] private int _startMoneyCount;
    public int StartMoneyCount => _startMoneyCount;
}
