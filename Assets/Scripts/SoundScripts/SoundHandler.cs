using UnityEngine;
using AYellowpaper.SerializedCollections;

public class SoundHandler : MonoBehaviour
{
    private readonly int _audioSourceCount = 10;

    [SerializedDictionary("SoundType", "AudioClip")] [SerializeField]
    private SerializedDictionary<SoundType, AudioClip> _sounds;


    [SerializeField] private AudioSource _audioSource; 
    [SerializeField] private GameObject _audioSourcePrefab;

    private AudioSource[] _audioSources;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        AddAudioSource();
    }

    private void OnEnable()
    {
        SoundCaller.OnSoundCallOneShot += PlayOneShot;
        SoundCaller.OnSoundCall += PlaySound;
    }

    private void OnDisable()
    {
        SoundCaller.OnSoundCallOneShot -= PlayOneShot;
        SoundCaller.OnSoundCall -= PlaySound;
    }
    
    private void AddAudioSource()
    {
        _audioSources = new AudioSource[_audioSourceCount];
        for (int i = 0; i < _audioSourceCount; i++)
        {
            _audioSources[i] = Instantiate(_audioSourcePrefab, transform.position, Quaternion.identity, transform)
                .GetComponent<AudioSource>();
        }
    }

    private void PlayOneShot(SoundType soundType)
    {
        _audioSource.PlayOneShot(_sounds[soundType]);
    }

    private void PlaySound(SoundType soundType)
    {
        foreach (var freeAudioSource in _audioSources)
        {
            if (freeAudioSource.isPlaying)
            {
                continue;
            }
            freeAudioSource.PlayOneShot(_sounds[soundType]);
            break;
        }
    }
}