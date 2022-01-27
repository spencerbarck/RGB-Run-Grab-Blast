using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : CircleCollision
{
    public float MaxHealth = 200f;
    public float MinHealth = 50f;
    private float rgbToHealthConversion;
    [SerializeField]
    private PlayerMover PlayerMover;
    public void SetPlayerHealth()
    {
        rgbToHealthConversion = MaxHealth/255;

        health = GameManager.instance.PlayerStats.Health * rgbToHealthConversion;

        health += MinHealth;
    }
    public override void TakeDamage(Damage damage)
    {
        base.TakeDamage(damage);
        PlayerMover.Push(dmg.origin,dmg.pushForce);
    }
    protected override void Death()
    {
        GetComponent<PlayerMover>().enabled = false;
        GetComponent<PlayerShooter>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<PolygonCollider2D>().enabled = false;
        GameManager.instance.DisplayDeath();
    }

    public void IncreaseHealth(float rValue)
    {
        MaxHealth += rValue*rgbToHealthConversion;
        health += rValue*rgbToHealthConversion;
        if(health < MaxHealth)
        {
            health += (rValue*rgbToHealthConversion)/2;
            if(health>MaxHealth) health = MaxHealth;
        }
    }
    public float GetHealth()
    {
        return health;
    }
}
