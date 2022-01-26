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
    protected int rowCount = 10;
    [SerializeField]
    protected int columnCount = 1;
    private Vector3 startingPosition;
    private Vector3 currentPosition;
    public float ChanceToSpawn = 1f;
    [SerializeField]
    protected int spawnIterations = 1;
    protected int iterationsLeft = 1;
    [SerializeField]
    private float respawnDelay = 1f;
    private float nextRespawn = 0;
    [SerializeField]
    private bool startSpawned = true;
    protected virtual void Start()
    {
        nextRespawn = respawnDelay;
        startingPosition = GetComponent<Transform>().position;

        iterationsLeft = spawnIterations;

        if(startSpawned) SpawnObjects();
    }

    public void SpawnObjects()
    {
        if(iterationsLeft<1) return;
        
        currentPosition = startingPosition;

        for(int i = 0; i < columnCount; i++)
        {
            for(int n = 0; n < rowCount; n++)
            {
                //Spawn object if not randomly stopped
                float randSpawnCheck = Random.Range(0,1f);
                if(randSpawnCheck+ChanceToSpawn>1f)
                {
                    SpawnObject(currentPosition);
                }
                //Move to next position
                currentPosition = new Vector3(currentPosition.x,currentPosition.y + yDistance,1);
            }
            //Go to top of row
            currentPosition = new Vector3(currentPosition.x + xDistance,startingPosition.y,1);
        }

        iterationsLeft--;
    }

    private void Update()
    {
        if(Time.time > nextRespawn)
        {
            SpawnObjects();
            nextRespawn = Time.time + respawnDelay;
        }
    }

    public virtual void SpawnObject(Vector3 position)
    {
    }
}
