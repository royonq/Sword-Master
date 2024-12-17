using UnityEngine;
[CreateAssetMenu(fileName = "NewPlayer", menuName = "Player")]

public class PlayerStats : MobStats
{
    [SerializeField] private float _moneyCount;
    public float MoneyCount { get { return _moneyCount; } }
}
