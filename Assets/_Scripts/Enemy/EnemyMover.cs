using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : CircleMovement
{
    public float MaxSpeed = 8f;
    public float MinSpeed = 2f;
    private float rgbToSpeedConversion;
    Vector2 movement;

    private float walkTimerTime = 3f;
    private float walkTimer = 0f;

    protected override void Start()
    {
        base.Start();

        rgbToSpeedConversion = MaxSpeed/255;
        speed = GetComponent<SpriteRenderer>().color.g*rgbToSpeedConversion;
        if(speed<MinSpeed)
            speed = MinSpeed;
    }
    private void Update()
    {
        //Get input
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
        if(walkTimer<walkTimerTime)
        {
            walkTimer += Time.deltaTime;
            //movement.x = 1f;
        }
        else movement.x = 0f;
    }

    private void FixedUpdate()
    {
        //Move player
        rigidBody.MovePosition(rigidBody.position + movement * speed * Time.fixedDeltaTime);
    }
}