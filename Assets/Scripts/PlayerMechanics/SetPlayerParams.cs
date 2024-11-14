using UnityEngine;

public class SetPlayerParams : Mob
{
    [SerializeField] private PlayerStats _playerStats;
    private PlayerMovement _playerMovement;
    private Health _health;
    private void Start()
    {
        SetPlayerStats();
    }
    private void SetPlayerStats()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerMovement.MovementSpeed = _playerStats.Speed;

        _health = GetComponent<Health>();
        _health.CurrentHealth = _playerStats.Health;
    }
}
