using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera Camera;
    void Start()
    {
        Camera = GetComponent<Camera>();
    }
}
