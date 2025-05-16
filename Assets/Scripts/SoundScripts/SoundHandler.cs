using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

public class SoundHandler : MonoBehaviour
{
    [SerializedDictionary("SoundType", "AudioClip")] [SerializeField]
    private SerializedDictionary<SoundType, AudioClip> _sounds;

    private List<AudioSource> _audioSources;
    [SerializeField] private float _volumeBackgroundMusic;

    private void Start()
    {
        _audioSources = new List<AudioSource>(GetComponentsInChildren<AudioSource>());
    }

    private void OnEnable()
    {
        SoundCaller.OnSoundCall += PlaySound;
        SoundCaller.OnLoopSoundCall += PlayLoopSound;
    }

    private void OnDisable()
    {
        SoundCaller.OnSoundCall -= PlaySound;
        SoundCaller.OnLoopSoundCall -= PlayLoopSound;
    }

    private AudioSource GetFreeAudioSource()
    {
        foreach (var source in _audioSources)
        {
            if (!source.isPlaying)
                return source;
        }

        return null;
    }

    private void PlaySound(SoundType soundType)
    {
        var source = GetFreeAudioSource();
        source.PlayOneShot(_sounds[soundType]);
    }

    private void PlayLoopSound(SoundType soundType)
    {
        var source = GetFreeAudioSource();

        source.clip = _sounds[soundType];
        source.loop = true;
        source.volume = _volumeBackgroundMusic;
        source.Play();
    }
}