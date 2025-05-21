using UnityEngine;

public class Win : MonoBehaviour
{
    private void OnEnable()
    {
        SpawnEnemies.OnGameWin += GameWin;
    }

    private void OnDisable()
    {
        SpawnEnemies.OnGameWin -= GameWin;
    }

    private void GameWin()
    {
        Debug.Log("The Winn");  
        SoundCaller.SwitchBackgroundMusic(SoundType.calmMusic);
    }
}