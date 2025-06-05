
using UnityEngine;

public class AbilityStats : ScriptableObject
{
    [SerializeField] protected float _cooldown;
    public float Cooldown => _cooldown;

    [SerializeField] private Sprite _abilityIcon;
    public Sprite AbilityIcon => _abilityIcon;

    [SerializeField] private SoundType _abilitySound;
    public SoundType AbilitySound => _abilitySound;
}
