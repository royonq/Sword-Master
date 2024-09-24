using UnityEngine;
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PausePanel _pausePannel;
    private PlayerMovement _playerMovement;
    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        Vector2 movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _playerMovement.MoveDirection = movementDirection;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pausePannel.SetPanelActive();
        }
    }
}
