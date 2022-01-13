using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float MaxDamage = 50f;
    public float MinDamage = 12.5f;
    private float damage;
    private float rgbToDamageConversion;
    private void Start()
    {
        //Sets projectile color to the same color as the player
        GetComponent<SpriteRenderer>().color = GameManager.instance.playerColor;

        rgbToDamageConversion = MaxDamage/255;

        //Sets the projectile damage to correspond to the player color
        damage = GameManager.instance.PlayerStats.Damage * rgbToDamageConversion;

        if(damage<MinDamage)
            damage = MinDamage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyCollision enemy = collision.gameObject.GetComponent<EnemyCollision>();

        if(enemy != null)
            enemy.TakeDamage(damage);

        Destroy(gameObject);
    }
}
