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

        GetComponent<SpriteRenderer>().color = GameManager.instance.playerColor;
        rgbToDamageConversion = MaxDamage/255;
        damage = GameManager.instance.PlayerStats.Damage * rgbToDamageConversion;
        if(damage<MinDamage)
            damage = MinDamage;
        Debug.Log("Player Damage " + damage);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyCollision enemy = collision.gameObject.GetComponent<EnemyCollision>();

        if(enemy != null)
            enemy.TakeDamage(damage);
        Destroy(gameObject);
    }
}
