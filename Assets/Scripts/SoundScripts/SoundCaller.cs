using System;

public static class SoundCaller
{
    public static Action<SoundType> OnSoundCallOneShot;
    public static Action<SoundType> OnSoundCall;
    public static void PlaySoundOneShot(SoundType soundType)
    {
        OnSoundCallOneShot?.Invoke(soundType);
    }
    public static void PlaySound(SoundType soundType)
    {
        OnSoundCall?.Invoke(soundType);
    }
}