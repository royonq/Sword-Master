using UnityEngine;
using UnityEngine.InputSystem;

public class CursorFolower : MonoBehaviour
{
    private void Update()
    {
        transform.position = Mouse.current.position.ReadValue();
    }
}
