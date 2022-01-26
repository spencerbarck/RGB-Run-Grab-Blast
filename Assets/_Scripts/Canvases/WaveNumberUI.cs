using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveNumberUI : MonoBehaviour
{
    [SerializeField]
    private Text waveText;
    private Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;
        transform.position = new Vector3(startingPosition.x,startingPosition.y+300f,startingPosition.z);
    }
    void Update()
    {
        waveText.text=WaveManager.instance.WaveNumber.ToString();
    }

    public void ShowCount()
    {
        transform.position = startingPosition;
    }
}
