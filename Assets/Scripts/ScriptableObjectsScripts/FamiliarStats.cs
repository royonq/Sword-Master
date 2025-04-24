using UnityEngine;

[CreateAssetMenu(fileName = "NewFamiliar", menuName = "Data/Familiar")]
public class FamiliarStats : ScriptableObject
{
    [SerializeField] private float _familiarSpeed;
    public float FamiliarSpeed => _familiarSpeed;
}
