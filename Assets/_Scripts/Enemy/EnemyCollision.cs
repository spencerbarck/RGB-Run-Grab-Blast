using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : CircleCollision
{
    public float MaxHealth = 300f;
    public float MinHealth = 50f;
    private float rgbToHealthConversion;
    public float MaxDamage = 50f;
    public float MinDamage = 10f;
    public float damageValue;
    private float rgbToDamageConversion;
    private Vector3 pushDirection;
    private void Start()
    { 
        rgbToHealthConversion = MaxHealth/255;
        health = GetComponent<SpriteRenderer>().color.r * 255 * rgbToHealthConversion;
        rgbToDamageConversion = MaxDamage/255;
        damageValue = GetComponent<SpriteRenderer>().color.b * 255 * rgbToDamageConversion;
        
        if(health<MinHealth)
            health = MinHealth;
    }
    private void OnCollisionEnter2D(Collision2D collsion)
    {
        //Damage the player
        PlayerCollision player = collsion.gameObject.GetComponent<PlayerCollision>();
        if(player != null)
        {
            ApplyDamageToPlayer(player);
        }
    }
    private void ApplyDamageToPlayer(PlayerCollision player)
    {
        var dmg = new Damage();
        dmg.damageAmount = damageValue;
        dmg.origin = transform.position;
        dmg.pushForce = 2f;
        player.TakeDamage(dmg);
    }
    protected override void Death()
    {
        base.Death();
        GameManager.instance.RemoveEnemy();
    }
}
