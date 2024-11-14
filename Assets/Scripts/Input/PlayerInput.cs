using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInput : Mob
{
    [SerializeField] private PausePanel _pausePannel;
    private UseSatilateSword _useAbitities;
    private PlayerMovement _playerMovement;
    private void Start()
    {
        _useAbitities = GetComponent<UseSatilateSword>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _playerMovement.MoveDirection = context.ReadValue<Vector2>();
    }

    public void OnUseAbility(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _useAbitities.InstantiateSword();
        }
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _pausePannel.SetPanelActive();
        }
    }
}
