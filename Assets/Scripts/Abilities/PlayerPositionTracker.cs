using UnityEngine;

public class PlayerPositionTracker : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;
    private void Update()
    {
        TrackPlayer();
    }
    public void TrackPlayer()
    {
        transform.position = _playerPosition.position;
    }
}
