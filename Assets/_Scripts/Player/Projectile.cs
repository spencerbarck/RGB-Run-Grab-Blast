using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float MaxDamage = 50f;
    public float MinDamage = 12.5f;
    private float damageValue;
    private float rgbToDamageConversion;
    private void Start()
    {
        GetComponent<SpriteRenderer>().color = GameManager.instance.PlayerColor;
        SetDamage();
    }
    private void SetDamage()
    {
        //Sets the projectile damage to correspond to the player color
        rgbToDamageConversion = MaxDamage/255;
        damageValue = GameManager.instance.PlayerStats.Damage * rgbToDamageConversion;

        if(damageValue<MinDamage)
            damageValue = MinDamage;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        EnemyCollision enemy = collision.gameObject.GetComponent<EnemyCollision>();
        if(enemy != null)
        {
            ApplyDamageToEnemy(enemy);
        }
        Destroy(gameObject);
    }
    private void ApplyDamageToEnemy(EnemyCollision enemy)
    {
        var dmg = new Damage();
        dmg.damageAmount = damageValue;
        dmg.origin = transform.position;
        dmg.pushForce = 2f;
        enemy.TakeDamage(dmg);
    }
}
