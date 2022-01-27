using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private PickRGBUI pickRGB;
    public Transform Player;
    private Vector3 target, mousePosition, shakeOffset;
    private Vector3 refVel = Vector3.zero;
    private float cameraDistance = 3.5f;
    private float smoothTime = 0.1f;
    private float zStart;

    float shakeMag, shakeTimeEnd;
    Vector3 shakeVector;
    bool isShaking;
    private Camera MainCamera;
    private bool behaviorStarted = false;
    void Start()
    {
        pickRGB.colorPickEvent += StartCameraBehavior;

        target = Player.position;
        zStart = transform.position.z;

        MainCamera = Camera.main;
    }

    void Update()
    {
        if(behaviorStarted)
        {
            smoothTime = Mathf.Lerp(smoothTime,0,Time.deltaTime);

            mousePosition = CaptureMousePosition();

            shakeOffset = UpdateShake();

            target = UpdateTargetPosition();

            UpdateCameraPosition();

            //Camera Zoom
            if(((MainCamera.orthographicSize<30f)||(Input.GetAxis("Mouse ScrollWheel")>0))&&
                ((MainCamera.orthographicSize>5f)||(Input.GetAxis("Mouse ScrollWheel")<0)))
                MainCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * 10f;
        }
    }
    private void StartCameraBehavior()
    {
        behaviorStarted = true;
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
        Vector3 position = Player.transform.position + mouseOffset;
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
