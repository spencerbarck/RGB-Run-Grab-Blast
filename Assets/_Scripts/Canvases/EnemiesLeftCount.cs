using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesLeftCount : MonoBehaviour
{
    [SerializeField]
    private Text healthText;
    private Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;
        transform.position = new Vector3(startingPosition.x,startingPosition.y+300f,startingPosition.z);
    }
    void Update()
    {
        healthText.text=GameManager.instance.EnemyCount.ToString();
    }

    public void ShowCount()
    {
        transform.position = startingPosition;
    }
}
