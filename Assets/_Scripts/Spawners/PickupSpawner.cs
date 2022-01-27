using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : ObjectSpawner
{
    [SerializeField]
    private GameObject pickupToSpawn;
    int tempSpawnIterations;
    [SerializeField]
    private WaveButton waveButton;
    protected override void Start()
    {
        tempSpawnIterations = spawnIterations;
        spawnIterations = 0;
        
        base.Start();
    }
    public override void SpawnObject(Vector3 position)
    {
        if(WaveManager.instance.PickupsLeftInWave>0)
        {
            Instantiate(pickupToSpawn,position,Quaternion.identity);
            WaveManager.instance.PickupsLeftInWave--;
        }
        else
        {
            iterationsLeft = 0;
            spawnIterations = 0;
        }
    }
}
