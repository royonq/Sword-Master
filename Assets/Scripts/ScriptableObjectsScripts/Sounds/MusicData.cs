using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayer", menuName = "Data/Sounds/GameSounds")]
public class MusicData : ScriptableObject
{
    [SerializeField] private SoundType _castleMusic;
    public SoundType CastleMusic => _castleMusic;
    
   
    
    [SerializeField] private SoundType _bossFightMusic;
    public SoundType BossFightMusic => _bossFightMusic;
}