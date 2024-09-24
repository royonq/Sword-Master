using UnityEngine;

public class PausePannel : MonoBehaviour
{
    [SerializeField] private PauseController _pauseController;
    private void OnEnable()
    {
        _pauseController.Pause();
    }
    private void OnDisable()
    {
        _pauseController.Unpause();
    }
}
