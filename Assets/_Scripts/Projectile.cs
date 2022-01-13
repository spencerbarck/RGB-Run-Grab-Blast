using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float MaxDamage = 100f;
    public float MinDamage = 25f;
    private float damage;
    private float rgbToDamageConversion;
    private void Start()
    {
        GetComponent<SpriteRenderer>().color = GameManager.instance.playerColor;
        rgbToDamageConversion = MaxDamage/255;
        damage = GameManager.instance.PlayerStats.Damage * rgbToDamageConversion;
        if(damage<MinDamage)
            damage = MinDamage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(damage);
        Destroy(gameObject);
    }
}
