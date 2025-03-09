using UnityEngine;


[CreateAssetMenu(fileName = "NewPlayer", menuName = "Data/Damageble/Player")]
public class PlayerStats : MobStats
{
    [SerializeField] private int _startMoney;
    public int StartMoney => _startMoney;
}