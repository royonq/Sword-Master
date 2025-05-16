using UnityEngine;

[CreateAssetMenu(fileName = "NewDamageable", menuName = "Data/Damageable/Damageable")]
public class DamagebleStats : ScriptableObject
{
    [SerializeField] protected float _maxHealth;
    public float MaxHealth => _maxHealth;

    [SerializeField] private SoundType _takeDamageSound;
    public SoundType TakeDamageSound => _takeDamageSound;
}