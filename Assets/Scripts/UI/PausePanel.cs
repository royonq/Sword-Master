using UnityEngine;

public class PausePanel : MonoBehaviour
{
   

    [SerializeField] private PauseController _pauseController;
    private void Start()
    {
        PlayerInput.OnPauseEnable += SetPanelActive;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        PlayerInput.OnPauseEnable -= SetPanelActive;
    }

    private void OnEnable()
    {
        _pauseController.SetTimeScale(0);
    }

    private void OnDisable()
    {
        _pauseController.SetTimeScale(1);
    }

    private void SetPanelActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
