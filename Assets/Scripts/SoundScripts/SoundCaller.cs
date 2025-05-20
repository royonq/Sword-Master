using System;

public static class SoundCaller
{
    public static Action<SoundType,bool> OnSoundCall;
    public static Action<SoundType> OnMusicSwitch;
    
    public static void PlaySound(SoundType soundType, bool useOneShot)
    {
        OnSoundCall?.Invoke(soundType, useOneShot);
    }

    public static void SwitchBackgroundMusic(SoundType soundType)
    {
        OnMusicSwitch?.Invoke(soundType);
    }
}