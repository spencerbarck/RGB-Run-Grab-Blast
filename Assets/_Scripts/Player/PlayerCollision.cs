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
    private float cappedHealth;
    public void SetPlayerHealth()
    {
        rgbToHealthConversion = MaxHealth/255;

        health = GameManager.instance.PlayerStats.Health * rgbToHealthConversion;

        health += MinHealth;

        cappedHealth = health;
    }
    public override void TakeDamage(Damage damage)
    {
        base.TakeDamage(damage);
        PlayerMover.Push(dmg.origin,dmg.pushForce);
    }
    protected override void Death()
    {
        SoundManager.instance.StopSound("WaveStartMusic1");
        SoundManager.instance.PlaySound("DeathMusic");

        GameManager.instance.DisplayDeath();
        GetComponent<PlayerMover>().enabled = false;
        GetComponent<PlayerShooter>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<PolygonCollider2D>().enabled = false;
        FindObjectOfType<CameraManager>().enabled = false;
    }

    public void IncreaseHealth(float rValue)
    {
        cappedHealth += rValue*rgbToHealthConversion;
        health += rValue*rgbToHealthConversion;
        //if(health < cappedHealth)
        //{
        //    health += (rValue*rgbToHealthConversion)/2;
        //    if(health>cappedHealth) health = cappedHealth;
        //}
    }
    public float GetHealth()
    {
        return health;
    }
    public float GetCappedHealth()
    {
        return cappedHealth;
    }
    public void MaxOutHealth()
    {
        health = cappedHealth;
    }
}
