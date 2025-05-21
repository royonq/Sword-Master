using System.Collections;
using UnityEngine;
using AYellowpaper.SerializedCollections;
using UnityEngine.Serialization;

public class SoundHandler : MonoBehaviour
{
    private readonly int _audioSourceCount = 10;

    [SerializedDictionary("SoundType", "AudioClip")] [SerializeField]
    private SerializedDictionary<SoundType, AudioClip> _sounds;


    [SerializeField] private GameObject _audioSourcePrefab;

    [SerializeField] private AudioSource _playerSource;
    [SerializeField] private AudioSource _musicSource;

    private AudioSource[] _audioSources;
    private readonly int _audioVolume = 1;
    private readonly int _fadeTime = 1;

    private void Start()
    {
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
        _playerSource.PlayOneShot(_sounds[soundType]);
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
        yield return FadeVolume(_musicSource.volume, 0, _fadeTime);

        _musicSource.clip = _sounds[soundType];
        _musicSource.Play();

        yield return FadeVolume(0, _audioVolume, _fadeTime);
    }

    private IEnumerator FadeVolume(float volumeFrom, float volumeTo, float duration)
    {
        for (float elapsedTime = 0; elapsedTime < duration; elapsedTime += Time.fixedDeltaTime)
        {
            _musicSource.volume = Mathf.Lerp(volumeFrom, volumeTo, elapsedTime / duration);
            yield return new WaitForFixedUpdate();
        }

        _musicSource.volume = volumeTo;
    }
}
