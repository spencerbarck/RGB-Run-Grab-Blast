using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveButton : MonoBehaviour
{
    [SerializeField]
    private Transform playerLocation;
    [SerializeField]
    private SpriteRenderer buttonSprite;
    [SerializeField]
    private float pressRange;
    private bool isPressed = false;

    public delegate void PressEvent();
    public event PressEvent pressEvent;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&&Vector3.Distance(playerLocation.position,transform.position)<=pressRange)
        {
            if(isPressed)
            {
                isPressed = false;
                buttonSprite.enabled=true;
            }
            else
            {
                isPressed = true;
                buttonSprite.enabled=false;

                if(pressEvent != null)
                    pressEvent();
            }
        }
    }
}
