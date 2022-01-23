using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CircleStats
{
    protected override void Start()
    {
        base.Start();
        AssignPlayerColor();
    }
    private void AssignPlayerColor()
    {
        GameManager.instance.PlayerColor = circleSpriteRenderer.color;
    }
}
