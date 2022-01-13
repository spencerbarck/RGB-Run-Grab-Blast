using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleStats : MonoBehaviour
{
    public float Health;
    public float Speed;
    public float Damage;
    public SpriteRenderer circleSpriteRenderer;
    protected virtual void Start()
    {
        circleSpriteRenderer = GetComponent<SpriteRenderer>();
        UpdateStats(circleSpriteRenderer.color);
    }

    public void UpdateStats(Color circleColor)
    {
        Health = circleColor.r*255;
        Speed = circleColor.g*255;
        Damage = circleColor.b*255;
    }
}
