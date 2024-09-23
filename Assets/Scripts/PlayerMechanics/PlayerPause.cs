using UnityEngine;

public class PlayerPause : MonoBehaviour
{
    [SerializeField] private GameObject pausePannel;
    public void Pause()
    {
        pausePannel.SetActive(!pausePannel.activeSelf);
    }
}
