using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject pausePannel;
    public void SwichPause()
    {
        pausePannel.SetActive(!pausePannel.activeSelf);
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Unpause()
    {
        Time.timeScale = 1;
    }
}
