using System;

public static class SoundCaller
{
    public static Action<SoundType,bool> OnSoundCall;
    
    public static void PlaySound(SoundType soundType, bool useOneShot)
    {
        OnSoundCall?.Invoke(soundType, useOneShot);
    }
}