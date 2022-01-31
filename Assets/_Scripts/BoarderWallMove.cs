using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarderWallMove : MonoBehaviour
{
    [SerializeField]
    private PickRGBUI pickRGB;
    public float timeRemaining = 30;
    private bool isWaiting = false;
    private bool isMoving = false;
    private bool isReturning = false;
    [SerializeField]
    private string wallType;
    private Vector3 startingPosition;
    private Vector3 movedPosition;
    private void Start()
    {
        startingPosition = transform.position;
        pickRGB.colorPickEvent += StartWaiting;
        GameManager.instance.lastKillEvent += StartReturning;
        switch(wallType)
        {
        case "Left":
            movedPosition = new Vector3(startingPosition.x+11.75f,startingPosition.y,startingPosition.z);
            break;
        case "Right":
            movedPosition = new Vector3(startingPosition.x-11.75f,startingPosition.y,startingPosition.z);
            break;
        case "Up":
            movedPosition = new Vector3(startingPosition.x,startingPosition.y-11.75f,startingPosition.z);
            break;
        case "Down":
            movedPosition = new Vector3(startingPosition.x,startingPosition.y+11.75f,startingPosition.z);
            break;
        default:
            break;
        }
        
    }
    void Update()
    {
        if(isWaiting)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                isMoving = true;
                isWaiting = false;
                timeRemaining = 30f;
            }
        }
        if(isMoving)
        {
            transform.position = Vector3.Lerp(transform.position,movedPosition,Time.deltaTime/20);
        }
        if(isReturning)
        {
            transform.position = Vector3.Lerp(transform.position,startingPosition,Time.deltaTime*2);
        }
    }
    private void StartWaiting()
    {
        isWaiting = true;
        isReturning = false;
    }
    private void StartReturning()
    {
        isMoving=false;
        isReturning = true;
    }
}
