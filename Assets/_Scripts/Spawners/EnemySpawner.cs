using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ObjectSpawner
{
    
    [SerializeField]
    private GameObject enemyToSpawn;
    protected override void Start()
    {
        base.Start();
        GameManager.instance.AddEnemies(rowCount*columnCount*spawnIterations);
    }
    public override void SpawnObject(Vector3 position)
    {
        Instantiate(enemyToSpawn,position,Quaternion.identity);
    }
}
