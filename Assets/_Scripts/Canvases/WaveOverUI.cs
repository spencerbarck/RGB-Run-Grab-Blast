using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveOverUI : MonoBehaviour
{
    private Vector3 startingPosition;
    private bool isMove = false;
    void Start()
    {
        startingPosition = transform.position;
        GameManager.instance.lastKillEvent += StartMove;
    }

    void Update()
    {
        if(isMove)
        {
            transform.Translate(Vector3.right * Time.deltaTime*8f);
        }
    }
    private void StartMove()
    {
        isMove = true;
    }
}
