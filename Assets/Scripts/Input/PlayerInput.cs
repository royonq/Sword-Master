using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PausePanel _pausePannel;

    private Player _player;
    private void Start()
    {
        _player = GetComponent<Player>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _player.Move(context.ReadValue<Vector2>().normalized);
    }

    public void OnUseAbility(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _player.UseAbility();
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
