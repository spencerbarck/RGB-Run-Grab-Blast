using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuCamera : MonoBehaviour
{
    [SerializeField]
    private Transform playerBox;
    private Vector3 startPosition;
    bool movingUp = true;
    public float yIncrease = 0.001f;
    float yMax = 20f;
    float yMin = -20f;
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
            transform.position = startPosition + new Vector3(Mathf.Sin(Time.time/20)*10, transform.position.y + yIncrease/10, 0.0f);
        else
            transform.position = startPosition + new Vector3(Mathf.Sin(Time.time/20)*10, transform.position.y - yIncrease/10, 0.0f);
    }
}
