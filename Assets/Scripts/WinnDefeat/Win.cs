using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private SoundType _calmMusic;
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
        SoundCaller.SwitchBackgroundMusic(_calmMusic);
    }
}