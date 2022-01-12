using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private float _speed = 5f;

    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private Camera playerCamera;

    Vector2 movement;
    Vector2 mousePosition;
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePosition = playerCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movement * _speed * Time.fixedDeltaTime);

        Vector2 lookDirection = mousePosition - rigidBody.position;
        float rotationAngle = -1 * Mathf.Atan2(lookDirection.x,lookDirection.y) * Mathf.Rad2Deg;
        rigidBody.rotation=rotationAngle;
    }
}
