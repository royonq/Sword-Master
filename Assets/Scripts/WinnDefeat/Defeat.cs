using UnityEngine;

public class Defeat : MonoBehaviour
{
    private void OnEnable()
    {
        Gate.OnBrokenGate += GameOver;
        Player.OnPlayerDeath += GameOver;
    }

    private void OnDisable()
    {
        Gate.OnBrokenGate -= GameOver;
        Player.OnPlayerDeath -= GameOver;
    }

    private void GameOver()
    {
        Debug.Log("Defeat");
    }
}
