using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCollision : MonoBehaviour
{
    protected float health;
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health<=0) Death();
    }
    protected void Death()
    {
        Destroy(gameObject);
    }
}
