using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayer", menuName = "Data/Sounds/MobSounds/PlayerSound")]
public class PlayerSound : MobSound
{
    [SerializeField] private SoundType _ultimateSound;
    public SoundType UltimateSound => _ultimateSound;
}