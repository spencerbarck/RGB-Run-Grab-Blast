using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : ObjectSpawner
{
    [SerializeField]
    private GameObject pickupToSpawn;
    public override void SpawnObject(Vector3 position)
    {
        Instantiate(pickupToSpawn,position,Quaternion.identity);
    }
}
