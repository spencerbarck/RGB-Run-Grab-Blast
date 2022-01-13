using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public float MaxHealth = 200f;
    public float MinHealth = 50f;
    private float health;
    private float rgbToHealthConversion;

    private void Start()
    {
        rgbToHealthConversion = MaxHealth/255;
        health = GameManager.instance.PlayerStats.Health * rgbToHealthConversion;
        if(health<MinHealth)
            health = MinHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health<=0) Death();
    }

    private void Death()
    {
        
    }

}
