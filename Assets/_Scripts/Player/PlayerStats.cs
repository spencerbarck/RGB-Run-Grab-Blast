using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CircleStats
{
    
    protected override void Start()
    {

        base.Start();
        GameManager.instance.StorePlayerColor(circleSpriteRenderer.color);
        Debug.Log("Heath: "+Health+" Speed: "+Speed+" Damage: "+Damage);
    }
}
