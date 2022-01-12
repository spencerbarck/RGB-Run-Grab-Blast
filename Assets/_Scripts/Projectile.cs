using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Destructable
{
    private void Start()
    {
        GetComponent<SpriteRenderer>().color = GameManager.instance.playerColor;
    }
}
