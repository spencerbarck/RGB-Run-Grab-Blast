using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCanvas : MonoBehaviour
{
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private PickRGBUI pickRGB;
    private float maxTime = 30f;
    private float timeLeft = 30f;
    private bool timerStarted = false;
    private Vector3 startingPosition;
    private void Start()
    {
        startingPosition = transform.position;
        transform.position = new Vector3(startingPosition.x,startingPosition.y+300f,startingPosition.z);
        pickRGB.colorPickEvent += StartTimer;
        GameManager.instance.lastKillEvent += ResetTimer;
    }
    private void Update()
    {
        if(timerStarted)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                if(Mathf.RoundToInt(timeLeft)>9)timerText.text = "00:"+Mathf.RoundToInt(timeLeft);
                else timerText.text = "00:0"+Mathf.RoundToInt(timeLeft);

                if(timeLeft<5f) timerText.color = Color.red;
            }
            else
            {
                timerText.text = "00:00";
            }
        }
    }
    private void StartTimer()
    {
        timerStarted = true;
    }
    private void ResetTimer()
    {
        timerStarted = false;
        timerText.text = "00:30";
        timerText.color = Color.black;
        timeLeft = maxTime;
    }
    public void ShowTimer()
    {
        transform.position = startingPosition;
    }
}
