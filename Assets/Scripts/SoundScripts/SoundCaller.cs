using System;

public static class SoundCaller
{
    public static Action<SoundType> OnSoundCall;
    
    public static void PlaySound(SoundType soundType)
    {
        OnSoundCall?.Invoke(soundType);
    }
}