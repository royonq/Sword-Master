using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInput : MonoBehaviour
{
    public static event Action OnPauseEnable;
    public static event Action OnPlayerInteract;
    public static event Action OnTryStartTheWave;

    private Vector2 _movementDirection;

    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        _player.Move(_movementDirection);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movementDirection = context.ReadValue<Vector2>().normalized;
    }

    public void FirstAbility(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _player.FirstAbility();
        }
    }

    public void SecondAbility(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _player.SecondAbility();
        }
    }

    public void ThirdAbility(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _player.ThirdAbility();
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnPlayerInteract?.Invoke();
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnPauseEnable?.Invoke();
        }
    }

    public void OnTryStartWave(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnTryStartTheWave?.Invoke();
        }
    }
   
}
