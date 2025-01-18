using UnityEngine;

[CreateAssetMenu(fileName = "NewAbility", menuName = "Abilities")]
public class SateliteSwordStats : AbilityStats
{
    [SerializeField] private float _rotationSpeed;
    public float RotationSpeed { get { return _rotationSpeed; } }
}
