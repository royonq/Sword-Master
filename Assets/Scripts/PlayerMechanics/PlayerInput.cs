using UnityEngine;
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PausePanel _pausePannel;
    private PlayerMovement _playerMovement;
    private UseAbitities _useAbitities;
    [SerializeField] private ReferencePoint _referencePoint;
    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _useAbitities = GetComponent<UseAbitities>();
    }
    private void Update()
    {
        Vector2 movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _playerMovement.MoveDirection = movementDirection;

        _referencePoint.FixByPlayer(transform.position);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pausePannel.SetPanelActive();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _useAbitities.InstantiateSword();
        }
    }
}
