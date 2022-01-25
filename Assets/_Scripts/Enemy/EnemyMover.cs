using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : CircleMovement
{
    public float MaxSpeed = 8f;
    public float MinSpeed = 2f;
    private float rgbToSpeedConversion;

    [SerializeField]
    private Pathfinding.AIPath pathfinder;
    protected override void Start()
    {
        rgbToSpeedConversion = MaxSpeed/255;
        speed = GetComponent<SpriteRenderer>().color.g * 255 * rgbToSpeedConversion;

        speed += MinSpeed;
        
        pathfinder.maxSpeed = speed;

        base.Start();
        
    }
    //Old movement
    //Vector2 movement;
    //private float walkTimerTime = 3f;
    //private float walkTimer = 0f;
    private void Update()
    {
        /*
        if(walkTimer<walkTimerTime)
        {
            walkTimer += Time.deltaTime;
            movement.x = 0.25f;
        }
        else movement.x = 0f;*/
    }
    private void FixedUpdate()
    {
        /*
        rigidBody.MovePosition(rigidBody.position + movement * speed * Time.fixedDeltaTime);
        */
    }
}