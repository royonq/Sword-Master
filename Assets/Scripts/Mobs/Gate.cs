using UnityEngine;

public class Gate : Damageable
{
    [SerializeField] private Defeat _defeat;

    protected override void Die()
    {      
        _defeat.GameOver();
        Destroy(gameObject);
    }
}
