using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayer", menuName = "Data/Sounds/GameSounds")]
public class GameSounds : ScriptableObject
{
    [SerializeField] private SoundType _castleSound;
    public SoundType CastleSound => _castleSound;

    [SerializeField] private SoundType _waweSound;
    public SoundType WaweSound => _waweSound;

    [SerializeField] private SoundType _bossFightSound;
    public SoundType BossFightSound => _bossFightSound;
}