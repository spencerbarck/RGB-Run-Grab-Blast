using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : CircleCollision
{
    public float MaxHealth = 300f;
    public float MinHealth = 50f;
    private float rgbToHealthConversion;

    private void Start()
    {
        rgbToHealthConversion = MaxHealth/255;
        health = GetComponent<SpriteRenderer>().color.r * 255 * rgbToHealthConversion;
        
        if(health<MinHealth)
            health = MinHealth;
    }
}
