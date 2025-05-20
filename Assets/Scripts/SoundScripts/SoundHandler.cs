using System.Collections;
using UnityEngine;
using AYellowpaper.SerializedCollections;

public class SoundHandler : MonoBehaviour
{
    private readonly int _audioSourceCount = 10;

    [SerializedDictionary("SoundType", "AudioClip")] [SerializeField]
    private SerializedDictionary<SoundType, AudioClip> _sounds;


    [SerializeField] private GameObject _audioSourcePrefab;
    [SerializeField] private float _audioVolume;
    [SerializeField] private float _fadeTime;

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
        SoundCaller.OnMusicSwitch += SwitchBackgroundMusic;
    }

    private void OnDisable()
    {
        SoundCaller.OnSoundCall -= PlaySound;
        SoundCaller.OnMusicSwitch -= SwitchBackgroundMusic;
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

    private void PlaySound(SoundType soundType, bool useOneShot)
    {
        if (useOneShot)
        {
            PlayOneShot(soundType);
            return;
        }

        PlayFromPool(soundType);
    }

    private void PlayOneShot(SoundType soundType)
    {
        _audioSource.PlayOneShot(_sounds[soundType]);
    }

    private void PlayFromPool(SoundType soundType)
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

    private void SwitchBackgroundMusic(SoundType soundType)
    {
        StartCoroutine(FadeMusic(soundType));
    }

    private IEnumerator FadeMusic(SoundType soundType)
    {
        var newClip = _sounds[soundType];
        
        yield return FadeVolume(_audioSource.volume, 0, _fadeTime);

        _audioSource.clip = newClip;
        _audioSource.loop = true;
        _audioSource.Play();
        
        yield return FadeVolume(0, _audioVolume, _fadeTime);

        _audioSource.volume = _audioVolume;
    }

    private IEnumerator FadeVolume(float volumeFrom, float volumeTo, float duration)
    {
        for (float elapsedTime = 0; elapsedTime < duration; elapsedTime += Time.deltaTime)
        {
            _audioSource.volume = Mathf.Lerp(volumeFrom, volumeTo, elapsedTime / duration);
            yield return null;
        }
        _audioSource.volume = volumeTo;
    }
}
