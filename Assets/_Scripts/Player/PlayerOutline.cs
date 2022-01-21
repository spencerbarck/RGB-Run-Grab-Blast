using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutline : MonoBehaviour
{
    
    [SerializeField]
    public WaveButton waveButton;
    void Start()
    {
        waveButton.pressEvent += RemoveOutline;
    }
    public void RemoveOutline()
    {
        waveButton.pressEvent -= RemoveOutline;
        Destroy(gameObject);
    }
}
