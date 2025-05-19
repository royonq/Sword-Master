using System;

public static class SoundCaller
{
    public static Action<SoundType> OnSoundCallOneShot;
    public static Action<SoundType> OnSoundCall;
    
    public static void PlaySound(SoundType soundType, bool useOneShot)
    {
        if (useOneShot)
        {
            OnSoundCallOneShot?.Invoke(soundType);
        }
        else
        {
            OnSoundCall?.Invoke(soundType);
        }
    }
}