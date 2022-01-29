using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveOverSpawner : MonoBehaviour
{
    private Vector3 startingPosition;
    public GameObject GameObject;
    void Start()
    {
        GameManager.instance.lastKillEvent += StartMove;
    }

    private void StartMove()
    {
        Instantiate(GameObject,FindObjectOfType<CameraManager>().transform.position,Quaternion.identity);
    }
}
