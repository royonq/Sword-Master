using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInput : MonoBehaviour
{
    public static event Action OnPausePannelSetActive;
    public static event Action OnTradePannelSetActive;
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

    public void OnUseUltimate(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _player.UseUltimate();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _player.Attack();
        }
    }

    public void OnOpenTradePannel(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnTradePannelSetActive?.Invoke();
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnPausePannelSetActive?.Invoke();
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
