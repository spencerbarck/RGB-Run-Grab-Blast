using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssistUI : MonoBehaviour
{
    [SerializeField]
    private RectTransform scrollTransform;
    private Vector3 startingPosition; 
    [SerializeField]
    private PickRGBUI pickRGB;
    void Start()
    {
        startingPosition = scrollTransform.position;
        //scrollTransform.position = new Vector3(scrollTransform.position.x,scrollTransform.position.y+10000,scrollTransform.position.z);
        pickRGB.colorPickEvent += ShowScroll;
    }

    private void ShowScroll()
    {
        pickRGB.colorPickEvent -= ShowScroll;
        scrollTransform.position = startingPosition;
    }

    private void Update()
    {
        if(WaveManager.instance.WaveNumber>1)DeleteAssist();
    }

    public void DeleteAssist()
    {
        Destroy(gameObject);
    }
}
