using UnityEngine;
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        _playerMovement.Movement();
    }
    private void FixedUpdate()
    {
        _playerMovement.MovePlayer();
    }
}
