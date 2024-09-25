using UnityEngine;

public class ReferencePoint : MonoBehaviour
{
    public  void FixByPlayer(Vector3 playerPosition)
    {
        transform.position = playerPosition;
    }
}
