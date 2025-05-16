using UnityEngine;

[CreateAssetMenu(fileName = "NewSpawnerData", menuName = "Data/SpawnerData")]
public class SpawnerData : ScriptableObject
{
    [SerializeField] private float _spawnXmax;
    public float SpawnXmax => _spawnXmax;

    [SerializeField] private float _spawnXmin;
    public float SpawnXmin => _spawnXmin;


    [SerializeField] private float _spawnY;
    public float SpawnY => _spawnY;


    [SerializeField] private float _spawnRate;
    public float SpawnRate => _spawnRate;

    [SerializeField] private int[] _enemyWave;
    public int[] EnemyWave => _enemyWave;
    
    
    [SerializeField] private SoundType _waweMusic;
    public SoundType WaweMusic => _waweMusic;
}