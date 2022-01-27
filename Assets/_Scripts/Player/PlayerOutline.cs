using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutline : MonoBehaviour
{
    
    [SerializeField]
    //public WaveButton waveButton;
    private PickRGBUI pickRGB;
    
    void Start()
    {
        //waveButton.pressEvent += RemoveOutline;
        pickRGB.colorPickEvent += RemoveOutline;
    }
    public void RemoveOutline()
    {
        //waveButton.pressEvent -= RemoveOutline;
        pickRGB.colorPickEvent -= RemoveOutline;
        Destroy(gameObject);
    }
}
