using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : CircleCollision
{
    public float MaxHealth = 200f;
    public float MinHealth = 50f;
    private float rgbToHealthConversion;

    public void InitPlayerHealth()
    {
        rgbToHealthConversion = MaxHealth/255;

        health = GameManager.instance.PlayerStats.Health * rgbToHealthConversion;

        if(health<MinHealth)
            health = MinHealth;
    }
}
