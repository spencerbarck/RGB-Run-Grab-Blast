using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingObsticle : MonoBehaviour
{
    [SerializeField]
    private WaveButton waveButton;
    [SerializeField]
    private PickRGBUI pickRGB;
    private Vector3 startingPosition;
    private Vector3 openPosition;
    private bool isOpening = false;
    private bool isClosing = false;
    private float slideDistance = 2.5f;
    [SerializeField]
    private string SlideDirection = "Left";
    private bool startClosed=true;
    void Start()
    {
        pickRGB.colorPickEvent += StartOpening;
        waveButton.pressEvent += StartClosing;
        startingPosition = transform.position;
        switch(SlideDirection)
        {
        case "Left":
            openPosition = new Vector3(startingPosition.x-slideDistance,startingPosition.y,startingPosition.z);
            break;
        case "Right":
            openPosition = new Vector3(startingPosition.x+slideDistance,startingPosition.y,startingPosition.z);
            break;
        case "Up":
            openPosition = new Vector3(startingPosition.x,startingPosition.y+slideDistance,startingPosition.z);
            break;
        case "Down":
            openPosition = new Vector3(startingPosition.x,startingPosition.y-slideDistance,startingPosition.z);
            break;
        default:
            break;
        }
    }
    private void StartOpening()
    {
        transform.position = startingPosition;
        isOpening = true;
    }
    private void StartClosing()
    {
        if(startClosed==true)
        {
            startClosed = false;
            isClosing = true;
        }
        else
        {
            transform.position = openPosition;
            isClosing = true;
        }
    }
    private void Update()
    {
        if(isOpening)
        {
            Open();
        }
        if(isClosing)
        {
            Close();
        }
    }

    private void Open()
    {
        transform.position = Vector3.Lerp(transform.position,openPosition,Time.deltaTime);
        if((Mathf.Abs(transform.position.x - openPosition.x)<0.1f)&&(Mathf.Abs(transform.position.y - openPosition.y)<0.1f))
        {
            AstarPath.active.Scan();
            isOpening = false;
        }
    }

    private void Close()
    {
        transform.position = Vector3.Lerp(transform.position,startingPosition,Time.deltaTime*3);
        if((Mathf.Abs(transform.position.x - startingPosition.x)<0.1f)&&(Mathf.Abs(transform.position.y - startingPosition.y)<0.1f))
        {
            isClosing = false;
        }
    }
}
