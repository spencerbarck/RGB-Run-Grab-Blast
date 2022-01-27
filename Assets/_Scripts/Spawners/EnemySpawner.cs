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
    }
    public override void SpawnObject(Vector3 position)
    {
        if(WaveManager.instance.EnemiesLeftInWave>0)
        {
            GameManager.instance.AddEnemies(1);
            Instantiate(enemyToSpawn,position,Quaternion.identity);

            WaveManager.instance.EnemiesLeftInWave--;
        }
        else
        {
            iterationsLeft = 0;
            spawnIterations = 0;
        }
    }

    public void StartSpawning()
    {
        iterationsLeft = tempSpawnIterations;
        waveButton.pressEvent -= StartSpawning;
    }
}
