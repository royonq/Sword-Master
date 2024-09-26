using UnityEngine;

public class ReferencePoint : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;
    private void Update()
    {
        FixByPlayer();
    }
    public void FixByPlayer()
    {
        if (_playerPosition == null)
        {
            return;
        }
        transform.position = _playerPosition.position;
    }
}
