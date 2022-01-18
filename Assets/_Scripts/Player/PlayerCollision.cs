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

    public void InitPlayerHealth()
    {
        rgbToHealthConversion = MaxHealth/255;

        health = GameManager.instance.PlayerStats.Health * rgbToHealthConversion;

        if(health<MinHealth)
            health = MinHealth;
    }

    public override void TakeDamage(Damage damage)
    {
        base.TakeDamage(damage);
        PlayerMover.Push(dmg.origin,dmg.pushForce);
    }
    public float GetHealth()
    {
        return health;
    }
}
