using UnityEngine;

public class SwordAbilityManager : MonoBehaviour
{
    [SerializeField] private AbilitySateliteSword _abilitySateliteSword;
    public float Damage { get { return _abilitySateliteSword.Damage; } }
    public float RotationSpeed { get { return _abilitySateliteSword.RotationSpeed; } }
}
