using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteSword : MonoBehaviour
{

    [SerializeField] private Sword _sword;
    private float _rotationSpeed;
    private float _damage;
    private float _speed;
    private float _lifeTime;
    private void FixedUpdate()
    {
        RotateAroundPlayer();
    }
    public void Init(SateliteSwordStats stats)
    {
        _damage = stats.Damage;
        _speed = stats.Speed;
        _lifeTime = stats.Lifetime;
        _rotationSpeed = stats.RotationSpeed;
    }

    private void RotateAroundPlayer()
    {
        transform.Rotate(_rotationSpeed * Time.fixedDeltaTime * Vector3.forward);
    }
}
