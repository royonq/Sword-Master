using System;
using UnityEngine;

public class Gate : Damageable
{
    public static event Action OnBrokenGate;

    protected override void Die()
    {      
        OnBrokenGate?.Invoke();
        Destroy(gameObject);
    }
}
