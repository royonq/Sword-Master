using UnityEngine;

public class PlayerPositionTracker : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;
    private void Update()
    {
        FixByPlayer();
    }
    public void FixByPlayer()
    {
        transform.position = _playerPosition.position;
    }
}
