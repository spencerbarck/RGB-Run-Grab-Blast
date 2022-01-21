using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleStats : MonoBehaviour
{
    //Stores stats in RGB format
    public float Health;
    public float Speed;
    public float Damage;
    public SpriteRenderer circleSpriteRenderer;
    protected virtual void Start()
    {
        circleSpriteRenderer = GetComponent<SpriteRenderer>();
        UpdateStats(circleSpriteRenderer.color);
    }

    //Converts stats from 1-0 float to RBG and stores them in Stats
    public void UpdateStats(Color circleColor)
    {
        circleSpriteRenderer.color = circleColor;
        Health = circleColor.r*255;
        Speed = circleColor.g*255;
        Damage = circleColor.b*255;
    }
}
