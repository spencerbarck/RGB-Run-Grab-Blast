using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ObjectSpawner
{
    protected override void Start()
    {
        base.Start();
        GameManager.instance.AddEnemies(rowCount*columnCount*spawnIterations);
    }
}
