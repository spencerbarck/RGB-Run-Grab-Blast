using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuCamera : MonoBehaviour
{
    private Vector3 startPosition;
    bool movingUp = true;
    public float yIncrease = 0.01f;
    float yMax = 10f;
    float yMin = -10f;
    void Start()
    {
        startPosition = transform.position;
    }    
    void Update()
    {
        if((transform.position.y>yMax)&&movingUp)
        {
            movingUp = false;
        }
        if((transform.position.y<yMin)&&!movingUp)
        {
            movingUp = true;
        }
        
        if(movingUp)
            transform.position = startPosition + new Vector3(Mathf.Sin(Time.time/2)*10, transform.position.y + yIncrease, 0.0f);
        else
            transform.position = startPosition + new Vector3(Mathf.Sin(Time.time/2)*10, transform.position.y - yIncrease, 0.0f);
    }
}
