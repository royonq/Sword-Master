using UnityEngine;

[CreateAssetMenu(fileName = "NewSpawnerData", menuName = "Data/SpawnerData")]

public class SpawnerData : ScriptableObject
{
    [SerializeField] private float _spawnXmax;
    public float SpawnXmax { get { return _spawnXmax; } }

    [SerializeField] private float _spawnXmin;
    public float SpawnXmin { get { return _spawnXmin; } }


    [SerializeField] private float _spawnY;
    public float SpawnY { get { return _spawnY; } }


    [SerializeField] private float _spawnRate;
    public float SpawnRate { get { return _spawnRate; } }
    
    [SerializeField] private int _enemycount;
    public int Enemycount { get { return _enemycount; } }

}
