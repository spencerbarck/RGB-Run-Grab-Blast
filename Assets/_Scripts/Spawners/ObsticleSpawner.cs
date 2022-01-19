using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleSpawner : ObjectSpawner
{
    
    [SerializeField]
    private GameObject[] obsticlesToSpawn;
    [SerializeField]
    private float[] obsticleSpawnChance;
    public override void SpawnObject(Vector3 position)
    {
        int numberOfObsticles = obsticlesToSpawn.Length;
        int objectChosen = Random.Range(0,numberOfObsticles);
        
        Instantiate(obsticlesToSpawn[objectChosen],position,Quaternion.identity);
    }
}
