using UnityEngine;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private PauseController _pauseController;
    private void OnEnable()
    {
        _pauseController.SetTimeScale(0);
    }
    private void OnDisable()
    {
        _pauseController.SetTimeScale(1);
    }
    public void SetPanelActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
