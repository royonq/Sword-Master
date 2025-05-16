using UnityEngine;

public class MobSound : ScriptableObject
{
    [SerializeField] private SoundType _attackSound;
    public SoundType AttackSound => _attackSound;

    [SerializeField] private SoundType _takeDamageSound;
    public SoundType TakeDamageSound => _takeDamageSound;
}