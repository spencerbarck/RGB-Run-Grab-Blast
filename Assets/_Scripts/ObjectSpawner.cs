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
    void Start()
    {
        startingPosition = GetComponent<Transform>().position;
        currentPosition = startingPosition;

        for(int i = 0; i < rowCount; i++)
        {
            for(int n = 0; n < columnCount; n++)
            {
                Instantiate(objectToSpawn,currentPosition,Quaternion.identity);

                //Move to next position
                currentPosition = new Vector3(currentPosition.x,currentPosition.y + yDistance,1);
            }
            //Go to top of row
            currentPosition = new Vector3(currentPosition.x + xDistance,startingPosition.y,1);
        }
    }
}
