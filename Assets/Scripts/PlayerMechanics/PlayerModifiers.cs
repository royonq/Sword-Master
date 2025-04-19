using UnityEngine;

public class PlayerModifiers : MonoBehaviour
{
    
    private float _speedModifire = 1;


    public float SpeedUpgrade{set => _speedModifire += value; }
    
    public float SpeedModifire => _speedModifire;
    
    private void Awake()
    {
        ItemsDataHandler.OnModifier += GetPlayerModifiers;
    }

    private void OnDestroy()
    {
        ItemsDataHandler.OnModifier -= GetPlayerModifiers;
    }
    
    private PlayerModifiers GetPlayerModifiers()
    {
        return this;
    }
}