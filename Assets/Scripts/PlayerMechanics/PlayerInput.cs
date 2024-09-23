using UnityEngine;
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerPause _playerPause;
    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerPause = GetComponent<PlayerPause>();
    }
    private void Update()
    {
        Vector2 movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _playerMovement.MoveDirection = movementDirection;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _playerPause.Pause();
        }
    }
}
