using UnityEngine;


[CreateAssetMenu(fileName = "NewPlayer", menuName = "Data/Damageble/Player")]
public class PlayerStats : MobStats
{
    [SerializeField] private SoundType _ultimateSound;
    public SoundType UltimateSound => _ultimateSound;
}