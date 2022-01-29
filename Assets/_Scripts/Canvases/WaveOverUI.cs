using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveOverUI : MonoBehaviour
{
    private Vector3 startingPosition;
    
    public float targetTime = 4.0f;
    public float timer = 4f;
    void Start()
    {
        GetComponent<Canvas>().enabled=true;
        GameManager.instance.lastKillEvent += StartMove;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        GetComponent<CanvasScaler>().scaleFactor-=0.001f;
        if (timer <= 0.0f)
        {
            GetComponent<CanvasScaler>().scaleFactor-=1f;
            StopMove();
        }
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
