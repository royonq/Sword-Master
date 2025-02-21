using UnityEngine;

public class StartWave : MonoBehaviour
{
    [SerializeField] private SpawnEnemies _enemySpawner;
    [SerializeField] private GameObject _gate;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _enemySpawner.StartWave();

            _gate.SetActive(true);//change to animation
            gameObject.SetActive(false);
        }
    }
}
