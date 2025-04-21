using UnityEngine;

public class PlayerModifiers : MonoBehaviour
{
    private Player _player;
    
    private float _speedModifier = 1;
    public float SpeedUpgrade{set => _speedModifier += value; }
    public float SpeedModifier => _speedModifier;
    
    
    private float _damageModifier = 1;
    public float DamageUpgrade{set => _damageModifier += value; }
    public float DamageModifier => _damageModifier;
    
    
    private float _healthModifier = 1;

    public float HealthUpgrade
    {
        set { _healthModifier += value; _player.UpgradeMaxHealth(_healthModifier); }
    }

    private void Start()
    {
        _player = GetComponentInParent<Player>();
    }
    
    private void OnEnable()
    {
        ItemsDataHandler.OnModifier += GetPlayerModifiers;
    }

    private void OnDisable()
    {
        ItemsDataHandler.OnModifier -= GetPlayerModifiers;
    }
    
    private PlayerModifiers GetPlayerModifiers()
    {
        return this;
    }
}