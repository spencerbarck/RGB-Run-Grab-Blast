using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private float xDistance = 4f;
    [SerializeField]
    private float yDistance = 4f;
    [SerializeField]
    private int rowCount = 10;
    [SerializeField]
    private int columnCount = 1;
    private Vector3 startingPosition;
    private Vector3 currentPosition;
    [SerializeField]
    private GameObject objectToSpawn;
    public float ChanceToSpawn = 1f;
    public int objectsSpawned { get; private set; } = 0;

    [SerializeField]
    private int spawnIterations = 1;
    [SerializeField]
    private float respawnDelay = 1f;
    private float nextRespawn = 0;
    [SerializeField]
    private bool startSpawned = true;
    void Start()
    {
        nextRespawn = respawnDelay;
        startingPosition = GetComponent<Transform>().position;

        if(startSpawned) SpawnObjects();
    }

    public void SpawnObjects()
    {
        if(spawnIterations<1) return;
        
        currentPosition = startingPosition;

        for(int i = 0; i < rowCount; i++)
        {
            for(int n = 0; n < columnCount; n++)
            {
                //Spawn object if not randomly stopped
                float randSpawnCheck = Random.Range(0,1f);
                if(randSpawnCheck+ChanceToSpawn>1f)
                {
                    Instantiate(objectToSpawn,currentPosition,Quaternion.identity);
                    objectsSpawned++;
                }

                //Move to next position
                currentPosition = new Vector3(currentPosition.x,currentPosition.y + yDistance,1);
            }
            //Go to top of row
            currentPosition = new Vector3(currentPosition.x + xDistance,startingPosition.y,1);
        }
        AstarPath.active.Scan();

        spawnIterations--;
    }

    private void Update()
    {
        if(Time.time > nextRespawn)
        {
            SpawnObjects();
            nextRespawn = Time.time + respawnDelay;
        }

    }
}
