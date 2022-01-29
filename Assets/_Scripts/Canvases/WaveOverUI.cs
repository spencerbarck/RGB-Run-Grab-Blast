using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveOverUI : MonoBehaviour
{
    private Vector3 startingPosition;
    
    public float targetTime = 3.0f;
    public float timer = 0f;
    void Start()
    {
        GetComponent<Canvas>().enabled=false;
        GameManager.instance.lastKillEvent += StartMove;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer <= 0.0f)
        {
            StopMove();
            GetComponent<CanvasScaler>().scaleFactor=1f;
        }
        else
        GetComponent<CanvasScaler>().scaleFactor-=0.001f;
    }
 
    private void StartMove()
    {
        timer=targetTime;
        GetComponent<Canvas>().enabled=true;
    }
    private void StopMove()
    {
        GetComponent<Canvas>().enabled=false;
    }
}
