using System;
using UnityEngine;
using AYellowpaper.SerializedCollections;

public class SoundHandler : MonoBehaviour
{
    [SerializedDictionary("SoundType", "AudioClip")] [SerializeField]
    private SerializedDictionary<SoundType, AudioClip> _sounds;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        SoundCaller.OnSoundCall += PlaySound;
    }

    private void OnDisable()
    {
        SoundCaller.OnSoundCall -= PlaySound;
    }

    private void PlaySound(SoundType soundType)
    {
        _audioSource.PlayOneShot(_sounds[soundType]);
    }
}