using UnityEngine;
using AYellowpaper.SerializedCollections;

public class SoundHandler : MonoBehaviour
{
    private readonly int _audioSourceCount = 10;

    [SerializedDictionary("SoundType", "AudioClip")] [SerializeField]
    private SerializedDictionary<SoundType, AudioClip> _sounds;


    [SerializeField] private GameObject _audioSourcePrefab;

    private AudioSource[] _audioSources;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        AddAudioSource();
    }

    private void OnEnable()
    {
        SoundCaller.OnSoundCall += PlaySound;
    }

    private void OnDisable()
    {
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

    private void PlayFromPool(SoundType soundType)
    {
        foreach (var freeAudioSource in _audioSources)
        {
            if (!freeAudioSource.isPlaying)
            {
                freeAudioSource.PlayOneShot(_sounds[soundType]);
                break;
            }
        }
    }
    
    private void PlaySound(SoundType soundType, bool useOneShot)
    {
        if (useOneShot)
        {
            PlayOneShot(soundType);
        }
        else
        {
            PlayFromPool(soundType);
        }
    }
}