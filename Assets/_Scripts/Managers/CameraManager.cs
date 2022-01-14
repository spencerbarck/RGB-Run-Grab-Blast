using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform Player;
    private Vector3 target, mousePosition, refVel, shakeOffset;
    private float cameraDistance = 3.5f;
    private float smoothTime = 0.2f;
    private float zStart;

    float shakeMag, shakeTimeEnd;
    Vector3 shakeVector;
    bool isShaking;
    //public Camera Camera;
    void Start()
    {
        //Camera = GetComponent<Camera>();
        target = Player.position;
        zStart = transform.position.z;
    }

    void Update()
    {
        mousePosition = CaptureMousePosition();

        shakeOffset = UpdateShake();

        target = UpdateTargetPosition();

        UpdateCameraPosition();
    }

    Vector3 CaptureMousePosition(){
        Vector2 position = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        position *=2;
        position -= Vector2.one;

        //Keep distance accurate around edges of screen
        if(Mathf.Abs(position.x)>0.9f || Mathf.Abs(position.y)>0.9f)
        {
            position = position.normalized;
        }
        return position;
    }

    Vector3 UpdateTargetPosition()
    {
        Vector3 mouseOffset = mousePosition * cameraDistance;
        Vector3 position = Player.position + mouseOffset;
        position += shakeOffset;
        position.z = zStart;
        return position;
    }

    void UpdateCameraPosition()
    {
        Vector3 tempPosition;

        tempPosition = Vector3.SmoothDamp(transform.position, target, ref refVel, smoothTime);

        transform.position = tempPosition;
    }

    public void ScreenShake(Vector3 direction, float magnitude, float length)
    {
        isShaking = true;
        shakeVector = direction;
        shakeMag = magnitude;
        shakeTimeEnd = Time.time + length;
    }

    Vector3 UpdateShake()
    {
        if (!isShaking || Time.time > shakeTimeEnd)
        {
            isShaking = false;
            return Vector3.zero;
        }

        Vector3 tempOffset = shakeVector;
        tempOffset *= shakeMag;
        return tempOffset;
    }
}
