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
    public void SetPlayerSpeed()
    {
        rgbToSpeedConversion = MaxSpeed/255;

        speed = GameManager.instance.PlayerStats.Speed * rgbToSpeedConversion;
        speed += MinSpeed;
        
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
        /*
        if((movement.x==1)&&(movement.y==1))
        {
            movement.x=0.5f;
            movement.y=0.5f;
        }
        if((movement.x==-1)&&(movement.y==1))
        {
            movement.x=-0.5f;
            movement.y=0.5f;
        }
        if((movement.x==1)&&(movement.y==-1))
        {
            movement.x=0.5f;
            movement.y=-0.5f;
        }
        if((movement.x==-1)&&(movement.y==-1))
        {
            movement.x=-0.5f;
            movement.y=-0.5f;
        }*/
        Vector2 moveNormal = movement.normalized;
        Vector2 moveNoForce = moveNormal * speed;
        
        //Apply push direction
        moveNoForce.x += pushDirection.x;
        moveNoForce.y += pushDirection.y;

        rigidBody.velocity = moveNoForce * Time.deltaTime * 100;
        
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, 1f);

        PlayerSpriteFaceMouse();
    }
    private void PlayerSpriteFaceMouse()
    {
        Vector2 lookDirection = mousePosition - rigidBody.position;
        float rotationAngle = -1 * Mathf.Atan2(lookDirection.x,lookDirection.y) * Mathf.Rad2Deg;
        rigidBody.rotation=rotationAngle;
    }
    public void Push(Vector3 pushOrigin, float force)
    {
        GetComponent<Rigidbody2D>().AddForce((transform.position - pushOrigin)*force*50);
        //pushDirection = (transform.position - pushOrigin).normalized * force;
    }
    public float GetSpeed()
    {
        return speed;
    }
}
