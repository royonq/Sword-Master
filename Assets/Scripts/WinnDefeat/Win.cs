using UnityEngine;

public class Win : MonoBehaviour
{
    private void OnEnable()
    {
        WaveHandler.OnGameWin += GameWin;
    }

    private void OnDisable()
    {
        WaveHandler.OnGameWin -= GameWin;
    }

    private void GameWin()
    {
        Debug.Log("The Winn");  
    }
}
