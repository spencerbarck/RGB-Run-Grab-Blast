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
    private Collider2D enemyCollider2D;
    public bool menuEnemy = false;
    private void Awake()
    {
        SetEnemyColor();
    }
    private void Start()
    {
        enemyCollider2D = GetComponent<Collider2D>();

        rgbToHealthConversion = MaxHealth/255;
        health = GetComponent<SpriteRenderer>().color.r * 255 * rgbToHealthConversion;
        health += MinHealth;
        
        rgbToDamageConversion = MaxDamage/255;
        damageValue = GetComponent<SpriteRenderer>().color.b * 255 * rgbToDamageConversion;
        damageValue += MinDamage;
        
    }
    private void OnCollisionEnter2D(Collision2D collsion)
    {
        if(collsion.gameObject.layer == LayerMask.NameToLayer("OutOfBounds")||collsion.gameObject.layer == LayerMask.NameToLayer("Pickup"))
        {
            Physics2D.IgnoreCollision(collsion.gameObject.GetComponent<Collider2D>(),enemyCollider2D);
        }

        //Damage the player
        PlayerCollision player = collsion.gameObject.GetComponent<PlayerCollision>();
        if(player != null)
        {
            ApplyDamageToPlayer(player);
        }
    }
    private void ApplyDamageToPlayer(PlayerCollision player)
    {
        SoundManager.instance.PlaySound("Hurt");
        var dmg = new Damage();
        dmg.damageAmount = damageValue;
        dmg.origin = transform.position;
        dmg.pushForce = 100f;
        
        GetComponent<EnemyMover>().Push((player.transform.position-transform.position),10f);
        player.TakeDamage(dmg);
    }
    protected override void Death()
    {
        SoundManager.instance.PlaySound("EnemyDeath");
        base.Death();
        GameManager.instance.RemoveEnemy();
    } 
    private void SetEnemyColor()
    {
        if(!menuEnemy)
        {
            float r = 0;
            float g = 0;
            float b = 0;
            float maxColor;
            if(WaveManager.instance.WaveNumber-1<WaveManager.instance.EnemyColorInWave.Length)
                maxColor = WaveManager.instance.EnemyColorInWave[WaveManager.instance.WaveNumber-1];
            else
                maxColor = 2f;
            while((r+g+b<maxColor))
            {
                r = Random.Range(0f,1f);
                g = Random.Range(0f,1f);
                b = Random.Range(0f,1f);
            }
            GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f,r),Random.Range(0f,g),Random.Range(0f,b),1f);
        }
        else
        {
            float r = 0;
            float g = 0;
            float b = 0;
            
            r = Random.Range(0f,1f);
            g = Random.Range(0f,1f);
            b = Random.Range(0f,1f);
            GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f,r),Random.Range(0f,g),Random.Range(0f,b),1f);
        }
        
    }
}
