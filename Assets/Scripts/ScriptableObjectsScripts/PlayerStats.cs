using UnityEngine;
[CreateAssetMenu(fileName = "NewPlayer", menuName = "Player")]
public class PlayerStats : ScriptableObject
{
    [SerializeField] private float _speed;
    public float Speed { get { return Speed; } }
    [SerializeField] private float _health;
    public float Health { get { return Health; } }
}
