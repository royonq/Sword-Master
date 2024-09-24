using UnityEngine;
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PauseController _pauseController;
    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _pauseController = GetComponent<PauseController>();
    }
    private void Update()
    {
        Vector2 movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _playerMovement.MoveDirection = movementDirection;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseController.SwichPause();
        }
    }
}
