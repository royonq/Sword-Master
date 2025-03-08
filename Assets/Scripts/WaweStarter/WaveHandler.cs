using UnityEngine;

public class WaveHandler : MonoBehaviour
{
    [SerializeField] private SpawnEnemies _spawnEnemies;
    [SerializeField] private GameObject _startWaveButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _startWaveButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _startWaveButton.SetActive(false);
        }
    }

    public void StartWaveButton()
    {
        _spawnEnemies.StartWave();
        _startWaveButton.SetActive(false);
        gameObject.SetActive(false);
    } 
}