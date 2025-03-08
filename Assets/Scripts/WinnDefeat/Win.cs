using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private GameObject _waveHandler;
    
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
        _waveHandler.SetActive(true);
        Debug.Log("The Winn");  
    }
}