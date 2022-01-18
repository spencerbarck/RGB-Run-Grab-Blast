using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCollision : MonoBehaviour
{
    protected float health;
    protected Damage dmg;
    public virtual void TakeDamage(Damage damage)
    {
        dmg = damage;

        health -= damage.damageAmount;
        
        if(health<=0) Death();
    }
    protected virtual void Death()
    {
        Destroy(gameObject);
    }
}
