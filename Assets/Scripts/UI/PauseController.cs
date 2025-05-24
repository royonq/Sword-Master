using UnityEngine;

public class PauseController : MonoBehaviour
{   
    public void SetTimeScale(int timeScale)
    {
        Time.timeScale = timeScale; 
    }
}
