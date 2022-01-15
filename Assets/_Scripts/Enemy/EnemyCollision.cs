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
    public float damage;
    private float rgbToDamageConversion;
    private Vector3 pushDirection;

    private void Start()
    {
        
        rgbToHealthConversion = MaxHealth/255;
        health = GetComponent<SpriteRenderer>().color.r * 255 * rgbToHealthConversion;
        rgbToDamageConversion = MaxDamage/255;
        damage = GetComponent<SpriteRenderer>().color.b * 255 * rgbToDamageConversion;

        
        if(health<MinHealth)
            health = MinHealth;
    }
    private void OnCollisionEnter2D(Collision2D collsion)
    {
        //Damage the player
        PlayerCollision player = collsion.gameObject.GetComponent<PlayerCollision>();
        if(player != null)
        {
            player.TakeDamage(damage);
            
            PlayerMover playerMove = collsion.gameObject.GetComponent<PlayerMover>();
            if(playerMove != null)
            {
                //Find Vector between enemy and player
                pushDirection = (collsion.gameObject.GetComponent<Transform>().position - transform.position).normalized * 25f;
                //Push the Player
                playerMove.Push(pushDirection);
            }
        }
    }
}
