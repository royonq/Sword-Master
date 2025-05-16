using System;

public static class SoundCaller
{
    public static Action<SoundType> OnSoundCall;
    public static Action<SoundType> OnLoopSoundCall;
    
    public static void PlaySound(SoundType soundType)
    {
        OnSoundCall?.Invoke(soundType);
    }
    public static void PlayLoopSound(SoundType soundType)
    {
        OnLoopSoundCall?.Invoke(soundType);
    }
}