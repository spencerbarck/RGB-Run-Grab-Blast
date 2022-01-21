using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ObjectSpawner
{
    
    [SerializeField]
    private GameObject enemyToSpawn;
    [SerializeField]
    private WaveButton waveButton;
    private int tempSpawnIterations;
    protected override void Start()
    {
        tempSpawnIterations = spawnIterations;
        spawnIterations = 0;
        waveButton.pressEvent += StartSpawning;
        
        base.Start();

        GameManager.instance.AddEnemies(rowCount*columnCount*spawnIterations);
    }
    public override void SpawnObject(Vector3 position)
    {
        Instantiate(enemyToSpawn,position,Quaternion.identity);
    }

    public void StartSpawning()
    {
        iterationsLeft = tempSpawnIterations;
        waveButton.pressEvent -= StartSpawning;
    }
}
