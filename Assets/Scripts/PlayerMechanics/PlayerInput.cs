using UnityEngine;
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PausePanel _pausePannel;
    [SerializeField] private PlayerStats _playerStats;
    private PlayerMovement _playerMovement;
    private UseSatilateSword _useAbitities;
    private Health _health;
    private void Start()
    {
        SetPlayerStats();
    }
    private void Update()
    {
        Vector2 movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _playerMovement.MoveDirection = movementDirection;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pausePannel.SetPanelActive();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _useAbitities.InstantiateSword();
        }
    }
    private void SetPlayerStats()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerMovement.MovementSpeed = _playerStats.Speed;

        _health = GetComponent<Health>();
        _health.CurrentHealth = _playerStats.Health;

        _useAbitities = GetComponent<UseSatilateSword>();
    }
}
