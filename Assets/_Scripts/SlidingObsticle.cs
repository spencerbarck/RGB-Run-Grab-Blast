using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingObsticle : MonoBehaviour
{
    [SerializeField]
    private WaveButton waveButton;
    private Vector3 startingPosition;
    private Vector3 openPosition;
    private bool isMoving = false;
    private float slideDistance = 2.5f;
    void Start()
    {
        waveButton.pressEvent += MoveObsticle;
        startingPosition = transform.position;
        openPosition = new Vector3(startingPosition.x-slideDistance,startingPosition.y-slideDistance,startingPosition.z);
    }
    private void MoveObsticle()
    {
        waveButton.pressEvent -= MoveObsticle;
        isMoving = true;
    }
    private void Update()
    {
        if(isMoving)
        {
            if((transform.position.x>openPosition.x)&&(transform.position.y>openPosition.y)&&(transform.position.y<startingPosition.y+slideDistance))
            {
                transform.Translate(Vector3.left * Time.deltaTime);
            }
            else
            {
                AstarPath.active.Scan();
                Destroy(gameObject);
            }
        }
    }
}
