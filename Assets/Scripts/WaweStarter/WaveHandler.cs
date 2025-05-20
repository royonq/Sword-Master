using UnityEngine;


public class WaveHandler : MonoBehaviour
{
    [SerializeField] private SpawnEnemies _spawnEnemies;
    [SerializeField] private SoundType _battleMusic;
    private bool _isPlayerInZone;

    private void Start()
    {
        PlayerInput.OnTryStartTheWave += StartWaveButton;
    }

    private void OnDestroy()
    {
        PlayerInput.OnTryStartTheWave -= StartWaveButton;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isPlayerInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isPlayerInZone = false;
        }
    }

    private void StartWaveButton()
    {
        if (_isPlayerInZone)
        {
            _spawnEnemies.StartWave();
            SoundCaller.SwitchBackgroundMusic(_battleMusic);
            gameObject.SetActive(false);
        }
    } 
}