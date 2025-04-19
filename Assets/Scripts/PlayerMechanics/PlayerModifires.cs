using UnityEngine;

public class PlayerModifires : MonoBehaviour
{
    
    private float _speedModifire = 1;


    public float SpeedUpgrade{set => _speedModifire += value; }
    
    public float SpeedModifire => _speedModifire;
    
    private void OnEnable()
    {
        Item.OnModifier += GetPlayerModifiers;
    }

    private void OnDisable()
    {
        Item.OnModifier -= GetPlayerModifiers;
    }
    
    private PlayerModifires GetPlayerModifiers()
    {
        return this;
    }

}