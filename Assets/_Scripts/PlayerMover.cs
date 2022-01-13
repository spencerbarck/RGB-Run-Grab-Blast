using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float MaxSpeed = 8f;
    public float MinSpeed = 2f;
    private float speed;
    private float rgbToSpeedConversion;
    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private Camera playerCamera;
    Vector2 movement;
    Vector2 mousePosition;
    private void Start()
    {
        rgbToSpeedConversion = MaxSpeed/255;
        speed = GameManager.instance.PlayerStats.Speed * rgbToSpeedConversion;
        if(speed<MinSpeed)
            speed = MinSpeed;
    }
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePosition = playerCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movement * speed * Time.fixedDeltaTime);

        Vector2 lookDirection = mousePosition - rigidBody.position;
        float rotationAngle = -1 * Mathf.Atan2(lookDirection.x,lookDirection.y) * Mathf.Rad2Deg;
        rigidBody.rotation=rotationAngle;
    }
}
