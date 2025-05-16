using UnityEngine;
using AYellowpaper.SerializedCollections;
public class SoundHandler : MonoBehaviour
{
    [SerializedDictionary("ItemType", "Item")] [SerializeField]
    private SerializedDictionary<SoundType, AudioClip> _sounds;
    
   [SerializeField] private AudioSource _audioSource;
    
    private void PlaySound(SoundType soundType)
    {
        _audioSource.PlayOneShot(_sounds[soundType]);
    }
}
