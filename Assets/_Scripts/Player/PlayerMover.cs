using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : CircleMovement
{
    public float MaxSpeed = 8f;
    public float MinSpeed = 2f;
    private float rgbToSpeedConversion;
    [SerializeField]
    private Camera playerCamera;
    Vector2 movement;
    Vector2 mousePosition;
    Vector3 pushDirection;
    bool isPush;

    public void InitPlayerSpeed()
    {
        rgbToSpeedConversion = MaxSpeed/255;

        speed = GameManager.instance.PlayerStats.Speed * rgbToSpeedConversion;
        if(speed<MinSpeed)
            speed = MinSpeed;
        
        pushDirection = Vector3.zero;
    }
    private void Update()
    {
        //Get input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Get mouse position
        mousePosition = playerCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        //Move player
        Vector2 moveAndSpeed = movement * speed;

        if(!isPush)
        {
            rigidBody.MovePosition(rigidBody.position + moveAndSpeed * Time.fixedDeltaTime);
        }
        else
        {
            Vector2 pushVector2 = new Vector2(pushDirection.x,pushDirection.y);
            rigidBody.MovePosition(rigidBody.position + pushVector2 * Time.fixedDeltaTime);
            isPush=false;
        }
        
        //Rotate to face mouse
        Vector2 lookDirection = mousePosition - rigidBody.position;
        float rotationAngle = -1 * Mathf.Atan2(lookDirection.x,lookDirection.y) * Mathf.Rad2Deg;
        rigidBody.rotation=rotationAngle;
    }

    public void Push(Vector3 pushOrigin,float force)
    {
        isPush = true;
        Debug.Log("PUSH!");
        pushDirection = (transform.position - pushOrigin).normalized * force;
    }
}
