using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CircleStats
{
    public PlayerCollision PlayerCollision;
    public PlayerMover PlayerMover;
    protected override void Start()
    {
        base.Start();
        //Store the player color in game manager
        GameManager.instance.playerColor = circleSpriteRenderer.color;
        PlayerCollision.InitPlayerHealth();
        PlayerMover.InitPlayerSpeed();
    }
}
