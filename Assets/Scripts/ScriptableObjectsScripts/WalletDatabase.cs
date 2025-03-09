using UnityEngine;
[CreateAssetMenu(fileName = "NewWallet", menuName = "Data/EarnItems/Wallet")]
public class WalletDatabase : ScriptableObject
{
    [SerializeField] private int _moneyCount;
    public int MoneyCount => _moneyCount;
}
