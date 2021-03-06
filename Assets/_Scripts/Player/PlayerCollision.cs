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
    private void OnCollisionEnter2D(Collision2D collsion)
    {

        if(collsion.gameObject.layer == LayerMask.NameToLayer("OutOfBounds"))
        {
            
            SoundManager.instance.PlaySoundLoud("BoarderHurt");
            var dmg = new Damage();
            if(collsion.gameObject.GetComponentInParent<BoarderWallMove>().wallType=="Left")
                dmg.origin = new Vector3(transform.position.x-0.5f,transform.position.y,transform.position.z);
            if(collsion.gameObject.GetComponentInParent<BoarderWallMove>().wallType=="Right")
                dmg.origin = new Vector3(transform.position.x+0.1f,transform.position.y,transform.position.z);
            if(collsion.gameObject.GetComponentInParent<BoarderWallMove>().wallType=="Up")
                dmg.origin = new Vector3(transform.position.x,transform.position.y+0.1f,transform.position.z);
            if(collsion.gameObject.GetComponentInParent<BoarderWallMove>().wallType=="Down")
                dmg.origin = new Vector3(transform.position.x,transform.position.y-0.1f,transform.position.z);
            dmg.damageAmount = 100f;
            dmg.pushForce = 150f;

            TakeDamage(dmg);
        }
    }
}
