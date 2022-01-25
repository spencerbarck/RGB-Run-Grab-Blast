using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRandomColor : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    public float minColor = 1;
    void Awake()
    {
        float r = 0;
        float g = 0;
        float b = 0;
        while((r+g+b<minColor))
        {
            r = Random.Range(0f,1f);
            g = Random.Range(0f,1f);
            b = Random.Range(0f,1f);
        }

        //spriteRenderer.color = new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f),1f);
        
    }
}
