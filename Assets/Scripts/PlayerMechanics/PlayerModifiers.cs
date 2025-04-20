using UnityEngine;

public class PlayerModifiers : MonoBehaviour
{
    
    private float _speedModifire = 1;
    public float SpeedUpgrade{set => _speedModifire += value; }
    public float SpeedModifire => _speedModifire;
    
    
    private float _damageModifire = 1;
    public float DamageUpgrade{set => _damageModifire += value; }
    public float DamageModifire => _damageModifire;
    
    private void OnEnable()
    {
        ItemsDataHandler.OnModifier += GetPlayerModifiers;
        Projectile.OnModifier += GetPlayerModifiers;
    }

    private void OnDisable()
    {
        ItemsDataHandler.OnModifier -= GetPlayerModifiers;
        Projectile.OnModifier -= GetPlayerModifiers;
    }
    
    private PlayerModifiers GetPlayerModifiers()
    {
        return this;
    }
}