using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuPlayerMover : MonoBehaviour
{
    [SerializeField]
    private Camera playerCamera;
    Vector2 mousePosition;
    protected Rigidbody2D rigidBody;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get mouse position
        mousePosition = playerCamera.ScreenToWorldPoint(Input.mousePosition);
        PlayerSpriteFaceMouse();
    }
    private void PlayerSpriteFaceMouse()
    {
        Vector2 lookDirection = mousePosition - rigidBody.position;
        float rotationAngle = -1 * Mathf.Atan2(lookDirection.x,lookDirection.y) * Mathf.Rad2Deg;
        rigidBody.rotation=rotationAngle;
    }
}
